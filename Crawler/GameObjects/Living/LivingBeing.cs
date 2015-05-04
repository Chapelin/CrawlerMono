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
        public Guid uniqueIdentifier;

        public Traits traits { get; set; }

        public FullStatistics statistics;

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
        private ILogPrinter logger;

        private ISchedulable sc;

        private List<IEffect<LivingBeing>> currentEffect;

        public LivingBeing(GameEngine game, Vector2 positionCell, string spriteName, ILogPrinter logprinter, IIntelligenceComponant ic, ISchedulable sc)
            : base(game, positionCell,  spriteName)
        {
            this.Inventory = new List<Item>();
            this.uniqueIdentifier = Guid.NewGuid();
            this.VisitedColor = Color.Transparent;
            this.statistics = new FullStatistics(new Statistics());
            this.logger = logprinter;
            this.z = 0.1F;
            this.ic = ic;
            this.sc = sc;
            this.currentEffect  = new List<IEffect<LivingBeing>>();
            sc.AddToSchedule(this);
        }

        public void AutoPlay()
        {
            this.ic.AutoPlay(this);
            Console.WriteLine(this.Description + " autoplayed");
        }

        public void DumpInventory()
        {
            this.logger.WriteLine("{0} inventory :", this.Description);
            foreach (var item in this.Inventory)
            {
                this.logger.WriteLine("   {0}", item.Description);
            }

        }

        public void GoMapDown()
        {
            this.logger.WriteLine(this.Description + " going down.");
            this.Game.ChangeMap(this, true);

        }

        public void GoMapUp()
        {
            this.logger.WriteLine(this.Description + " going up.");
            this.Game.ChangeMap(this, false);
        }

        public void AddEffect(IEffect<LivingBeing> eff)
        {
            if (eff.CanApply(this))
            {
                this.currentEffect.Add(eff);
                eff.Apply(this);
            }
        }

        public void TickEffects()
        {
            foreach (var effect in this.currentEffect)
            {
                effect.TurnToEnd--;
                if (effect.TurnToEnd <= 0)
                {
                    effect.UnApply(this);
                }
            }

            this.currentEffect.RemoveAll(x => x.TurnToEnd <= 0);
        }

        public List<IEffect<LivingBeing>> CurrentEffect
        {
            get
            {
                return this.currentEffect;
            }
        }
    }
}
