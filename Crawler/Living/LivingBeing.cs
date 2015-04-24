using Crawler.UI;

namespace Crawler.Living
{
    using System;
    using System.Collections.Generic;

    using Crawler.Engine;
    using Crawler.Items;

    using Microsoft.Xna.Framework;

    public class LivingBeing : MapDrawableComponent
    {
        public Guid uniqueIdentifier;

        public Traits traits { get; set; }

        public FullStatistics statistics;

        public bool IsUserControlled { get; set; }

        public List<Item> Inventory;


        private ILogPrinter logger;


        public LivingBeing(GameEngine game, Vector2 positionCell, string spriteName, ILogPrinter logprinter)
            : base(game, positionCell,  spriteName)
        {
            this.Inventory = new List<Item>();
            this.IsUserControlled = false;
            this.uniqueIdentifier = Guid.NewGuid();
            this.VisitedColor = Color.Transparent;
            this.statistics = new FullStatistics(new Statistics());
            this.logger = logprinter;
            this.z = 0.1F;
        }

        public virtual void AutoPlay()
        {
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
