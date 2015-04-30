﻿namespace Crawler.Living
{
    using System;
    using System.Collections.Generic;

    using Crawler.Components.IA;
    using Crawler.Engine;
    using Crawler.Items;
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


        public LivingBeing(GameEngine game, Vector2 positionCell, string spriteName, ILogPrinter logprinter, IIntelligenceComponant ic)
            : base(game, positionCell,  spriteName)
        {
            this.Inventory = new List<Item>();
            this.uniqueIdentifier = Guid.NewGuid();
            this.VisitedColor = Color.Transparent;
            this.statistics = new FullStatistics(new Statistics());
            this.logger = logprinter;
            this.z = 0.1F;
            this.ic = ic;
        }

        public void AutoPlay()
        {
            this.ic.AutoPlay(this);
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
