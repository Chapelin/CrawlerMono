using Crawler.UI;

namespace Crawler.Living
{
    using System;
    using System.Collections.Generic;

    using Engine;

    using Items;

    using Microsoft.Xna.Framework;

    public class LivingBeing : MapDrawableComponent
    {

        public Guid uniqueIdentifier;

        public Traits traits { get; set; }

        public FullStatistics statistics;

        public bool IsUserControlled { get; set; }

        public List<Item> Inventory;

        public String Name { get; set; }

        private ILogPrinter logger;


        public LivingBeing(GameEngine game, Vector2 positionCell, string spriteName, ILogPrinter logprinter)
            : base(game, positionCell,  spriteName)
        {
            Inventory = new List<Item>();
            IsUserControlled = false;
            uniqueIdentifier = Guid.NewGuid();
            VisitedColor = Color.Transparent;
            statistics = new FullStatistics(new Statistics());
            this.logger = logprinter;
        }

        public virtual void AutoPlay()
        {
        }

        public void DumpInventory()
        {
            this.logger.WriteLine("{0} inventory :",Name);
            foreach (var item in Inventory)
            {
                this.logger.WriteLine("   {0}",item.Description);
            }

        }

        public void GoMapDown()
        {
            this.logger.WriteLine(this.Name + " going down.");
            Game.ChangeMap(this,true);
            
        }

        public void GoMapUp()
        {
            this.logger.WriteLine(this.Name + " going up.");
            Game.ChangeMap(this, false);
        }
    }
}
