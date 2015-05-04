namespace Crawler.Components.ItemRelated.Implementation
{
    using System;

    using Crawler.GameObjects.Living;

    public class BasicEquipableItem : IEquipableComponent
    {
        private bool _isEquipped;

        private LivingBeing whoEquipped;

        // private Item itemTracked;

        private IStatisticsModifierComponent statisModifier;
        public BasicEquipableItem(IStatisticsModifierComponent modifier)
        {
            // this.itemTracked = i;
            this.statisModifier = modifier;
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
    }
}
