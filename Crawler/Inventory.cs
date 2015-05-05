using System.Collections.Generic;
using Crawler.GameObjects.Items;

namespace Crawler
{
    public class Inventory
    {
        public List<Item> Poutch;

        private Item _head;

        private Item _torso;

        private Item _foot;

        private Item _legs;

        private Item _ring;

        private Item _necklace;

        private Weapon _leftHandSlot;

        private Weapon _rightHandSlot;

        public Inventory()
        {
            this.Poutch = new List<Item>();
            
        }

        #region properties
        public Weapon LeftHandSlot
        {
            get
            {
                return _leftHandSlot;
            }
            set { _leftHandSlot = value; }
        }

        public Weapon RightHandSlot
        {
            get { return _rightHandSlot; }
            set { _rightHandSlot = value; }
        }

        public Item Necklace
        {
            get { return _necklace; }
            set { _necklace = value; }
        }

        public Item Ring
        {
            get { return _ring; }
            set { _ring = value; }
        }

        public Item Legs
        {
            get { return _legs; }
            set { _legs = value; }
        }

        public Item Foot
        {
            get { return _foot; }
            set { _foot = value; }
        }

        public Item Torso
        {
            get { return _torso; }
            set { _torso = value; }
        }

        public Item Head
        {
            get { return _head; }
            set { _head = value; }
        }

        #endregion properties
    }
}
