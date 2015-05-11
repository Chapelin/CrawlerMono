namespace Crawler.GameObjects.Living
{
    using System;
    using System.Collections.Generic;

    using Crawler.Components.IA;
    using Crawler.Components.Scheduling;
    using Crawler.Engine;
    using Crawler.GameObjects.Effect;

    using Microsoft.Xna.Framework;

    public class LivingBeing : MapComponent
    {
        public Guid UniqueIdentifier;

        public Traits Traits { get; set; }

        public FullStatistics Statistics;

        public bool IsUserControlled {
            get
            {
                return this.ic.IsUserControlled;
            }
            set
            {
                this.ic.IsUserControlled = value;
            }
        }

        public bool IsDead
        {
            get { return this.Statistics.CurrentPv <= 0; }
        }

        public Inventory Inventory;

        private IIntelligenceComponant ic;

        private ISchedulable sc;

        private readonly List<IEffect<LivingBeing>> _currentEffect;

        public LivingBeing(GameEngine game, Vector2 positionCell, string spriteName,IIntelligenceComponant ic, ISchedulable sc)
            : base(positionCell)
        {
            this.Inventory = new Inventory();
            this.UniqueIdentifier = Guid.NewGuid();
            this.VisitedColor = Color.Transparent;
            this.Statistics = new FullStatistics(new Statistics());
            this.ic = ic;
            this.sc = sc;
            this._currentEffect  = new List<IEffect<LivingBeing>>();
            this.AttachDrawingComponant(game,spriteName,0.1F);
            sc.AddToSchedule(this);
        }

        public void AutoPlay()
        {
            this.ic.AutoPlay(this);
            Console.WriteLine(this.Description + " autoplayed");
        }

        public void DumpInventory()
        {
            BlackBoard.LogPrinter.WriteLine("{0} inventory :", this.Description);
            foreach (var item in this.Inventory.Poutch)
            {
                BlackBoard.LogPrinter.WriteLine("   {0}", item.Description);
            }
        }

        public void GoMapDown()
        {
            BlackBoard.LogPrinter.WriteLine(this.Description + " going down.");
            BlackBoard.Game.ChangeMap(this, true);
        }

        public void GoMapUp()
        {
            BlackBoard.LogPrinter.WriteLine(this.Description + " going up.");
            BlackBoard.Game.ChangeMap(this, false);
        }

        public void AddEffect(IEffect<LivingBeing> eff)
        {
            if (eff.CanApply(this))
            {
                this._currentEffect.Add(eff);
                eff.Apply(this);
            }
        }

        public void TickEffects()
        {
            foreach (var effect in this._currentEffect)
            {
                effect.TurnToEnd--;
                if (effect.TurnToEnd <= 0)
                {
                    effect.UnApply(this);
                }
            }

            this._currentEffect.RemoveAll(x => x.TurnToEnd <= 0);
        }

        public List<IEffect<LivingBeing>> CurrentEffect
        {
            get
            {
                return this._currentEffect;
            }
        }

        public void Attack(LivingBeing obstacle)
        {
            var degats = this.CalculateOutputDamage();
            BlackBoard.LogPrinter.WriteLine("{0} attack {1} : {2}",this.Description, obstacle.Description, degats);
            var reduc = obstacle.CalculateReduceDamage();
            if (reduc >= degats)
            {
                BlackBoard.LogPrinter.WriteLine("No dammage");
            }
            else
            {
                obstacle.Statistics.RemovePv(degats);
                if (obstacle.IsDead)
                {
                    obstacle.Kill();
                }
            }

        }

        private int CalculateOutputDamage()
        {
            return this.Inventory.LeftHandSlot.CalculateOutputDamage(this);
        }

        public int CalculateReduceDamage()
        {
            return this.Statistics.BasicStatistics.Force / 3;
        }

        private void Kill()
        {
            Console.WriteLine("{0} is dead.", this.Description);
            this.UnregisterDrawingComponant();
            BlackBoard.CurrentMap.RemoveLivingBeing(this);
        }
    }
}
