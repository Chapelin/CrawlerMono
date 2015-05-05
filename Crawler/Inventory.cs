using System.Collections.Generic;
using Crawler.GameObjects.Items;

namespace Crawler
{
    public class Inventory
    {
        public List<Item> Poutch;

        public Item Head;

        public Item Torso;

        public Item Foot;

        public Item Legs;

        public Item Ring;

        public Item Necklace;

        public Item LeftHandSlot;

        public Item RightHandSlot;

        public Inventory()
        {
            this.Poutch = new List<Item>();
        }

    }
}
