namespace Crawler.Components.ItemRelated.Implementation
{
    using System;

    using Crawler.GameObjects.Items;
    using Crawler.GameObjects.Living;

    public class BasicUnequipable : IEquipableComponent
    {
        public bool CanEquip(LivingBeing lb)
        {
            return false;
        }

        public void Equip(LivingBeing lb)
        {
            throw new NotImplementedException();
        }

        public void UnEquip(LivingBeing lb)
        {
            throw new NotImplementedException();
        }

        public bool IsEquipped()
        {
            return false;
        }

        public Item.EquipementType typeOfItem
        {
            get
            {
                return Item.EquipementType.Other;
            }
        }
    }
}
