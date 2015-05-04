namespace Crawler.GameObjects.Living
{
    using System;
    using System.Collections.Generic;

    using Crawler.Components.IA;
    using Crawler.Components.Scheduling;
    using Crawler.Engine;
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
    }
}
