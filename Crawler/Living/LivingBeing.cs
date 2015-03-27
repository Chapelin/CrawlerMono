namespace Crawler.Living
{
    using System;
    using System.Collections.Generic;

    using Crawler.Items;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LivingBeing : MapDrawableComponent
    {

        public Guid uniqueIdentifier;

        public Statistics statistics;

        public bool IsUserControlled { get; set; }

        public List<Item> Inventory;

        public String Name { get; set; }

        public LivingBeing(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
            this.Inventory = new List<Item>();
            this.IsUserControlled = false;
            this.uniqueIdentifier = Guid.NewGuid();
            this.VisitedColor = Color.Transparent;
        }

        public virtual void AutoPlay()
        {
            Console.WriteLine("{0} Autoplayed", this.Name);
        }

        public void DumpInventory()
        {
            Console.WriteLine("{0} inventory :",this.Name);
            foreach (var item in Inventory)
            {
                Console.WriteLine("\t {0}",item.Description);
            }

        }
    }
}
