namespace Crawler.Living
{
    using System;
    using System.Collections.Generic;

    using Crawler.Engine;

    using Items;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class LivingBeing : MapDrawableComponent
    {

        public Guid uniqueIdentifier;

        public Traits traits { get; set; }

        public FullStatistics statistics;

        public bool IsUserControlled { get; set; }

        public List<Item> Inventory;

        public String Name { get; set; }

        public LivingBeing(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
            Inventory = new List<Item>();
            IsUserControlled = false;
            uniqueIdentifier = Guid.NewGuid();
            VisitedColor = Color.Transparent;
            this.statistics = new FullStatistics(new Statistics());
        }

        public virtual void AutoPlay()
        {
            Console.WriteLine("{0} Autoplayed", Name);
        }

        public void DumpInventory()
        {
            Console.WriteLine("{0} inventory :",Name);
            foreach (var item in Inventory)
            {
                Console.WriteLine("\t {0}",item.Description);
            }

        }

        public void GoMapDown()
        {
            Console.WriteLine("Going down");
            Game.ChangeMap(this,true);
            
        }

        public void GoMapUp()
        {
            Console.WriteLine("Going up");
            Game.ChangeMap(this, false);
        }
    }
}
