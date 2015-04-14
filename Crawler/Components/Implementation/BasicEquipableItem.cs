using Crawler.Living;

namespace Crawler.Components.Implementation
{
    using System;

    using Crawler.Items;

    public class BasicEquipableItem : IEquipableComponent
    {
        private bool _isEquipped;

        private LivingBeing whoEquipped;

        private Item itemTracked;

        public BasicEquipableItem(Item i)
        {
            this.itemTracked = i;
        }

        public bool CanEquip(LivingBeing lb)
        {
            return whoEquipped == null;
        }

        public void Equip(LivingBeing lb)
        {
            if (!this.CanEquip(lb))
            {
                throw new Exception("Can't equip");
            }


            this._isEquipped = true;
            this.whoEquipped = lb;
            Console.WriteLine(this.itemTracked.Description + " is equipped by "+ this.whoEquipped.Name);
        }

        public void UnEquip(LivingBeing lb)
        {
            this._isEquipped = false;
            this.whoEquipped = null;
            Console.WriteLine(this.itemTracked.Description + " is desequipped");
        }

        public bool IsEquipped()
        {
            return _isEquipped;
        }
    }
}
