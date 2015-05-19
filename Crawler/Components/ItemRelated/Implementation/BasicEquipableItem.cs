namespace Crawler.Components.ItemRelated.Implementation
{
    using System;

    using Crawler.GameObjects.Items;
    using Crawler.GameObjects.Living;

    public class BasicEquipableItem : IEquipableComponent
    {
        private bool _isEquipped;

        private LivingBeing whoEquipped;


        private IStatisticsModifierComponent statisModifier;
        public BasicEquipableItem(IStatisticsModifierComponent modifier)
        {
            this.statisModifier = modifier;
            this.typeOfItem = Item.EquipementType.Other;;
        }

        public bool CanEquip(LivingBeing lb)
        {
            return this.whoEquipped == null;
        }

        public void Equip(LivingBeing lb)
        {
            if (!this.CanEquip(lb))
            {
                throw new Exception("Can't equip");
            }

            this._isEquipped = true;
            this.whoEquipped = lb;
            lb.Statistics.ApplyBonus(this.statisModifier.StatisticDiffToApply);
        }

        public void UnEquip(LivingBeing lb)
        {
            this._isEquipped = false;
            this.whoEquipped = null;
            lb.Statistics.RemoveBonus(this.statisModifier.StatisticDiffToApply);
        }

        public bool IsEquipped()
        {
            return this._isEquipped;
        }

        public Item.EquipementType typeOfItem { get;  set; }
    }
}
