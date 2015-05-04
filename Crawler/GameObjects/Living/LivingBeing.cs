namespace Crawler.GameObjects.Living
{
    using System;
    using System.Collections.Generic;

    using Crawler.Components.IA;
    using Crawler.Components.Scheduling;
    using Crawler.Engine;
    using Crawler.GameObjects.Effect;
    using Crawler.GameObjects.Items;
    using Crawler.UI;

    using Microsoft.Xna.Framework;

    public class LivingBeing : MapDrawableComponent
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

        public List<Item> Inventory;

        private IIntelligenceComponant ic;

        private ISchedulable sc;

        private readonly List<IEffect<LivingBeing>> _currentEffect;

        public LivingBeing(GameEngine game, Vector2 positionCell, string spriteName,IIntelligenceComponant ic, ISchedulable sc)
            : base(game, positionCell,  spriteName)
        {
            this.Inventory = new List<Item>();
            this.UniqueIdentifier = Guid.NewGuid();
            this.VisitedColor = Color.Transparent;
            this.Statistics = new FullStatistics(new Statistics());
            this.z = 0.1F;
            this.ic = ic;
            this.sc = sc;
            this._currentEffect  = new List<IEffect<LivingBeing>>();
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
            foreach (var item in this.Inventory)
            {
                BlackBoard.LogPrinter.WriteLine("   {0}", item.Description);
            }

        }

        public void GoMapDown()
        {
            BlackBoard.LogPrinter.WriteLine(this.Description + " going down.");
            this.Game.ChangeMap(this, true);

        }

        public void GoMapUp()
        {
            BlackBoard.LogPrinter.WriteLine(this.Description + " going up.");
            this.Game.ChangeMap(this, false);
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
    }
}
