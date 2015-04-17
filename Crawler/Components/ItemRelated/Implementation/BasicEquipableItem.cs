namespace Crawler.Components.ItemRelated.Implementation
{
    using System;

    using Living;

    public class BasicEquipableItem : IEquipableComponent
    {
        private bool _isEquipped;

        private LivingBeing whoEquipped;

        //private Item itemTracked;


        private IStatisticsModifierComponent statisModifier;
        public BasicEquipableItem(IStatisticsModifierComponent modifier)
        {
            //this.itemTracked = i;
            statisModifier = modifier;
        }

        public bool CanEquip(LivingBeing lb)
        {
            return whoEquipped == null;
        }

        public void Equip(LivingBeing lb)
        {
            if (!CanEquip(lb))
            {
                throw new Exception("Can't equip");
            }


            _isEquipped = true;
            whoEquipped = lb;
            lb.statistics.ApplyBonus(statisModifier.StatisticDiffToApply);
            //Console.WriteLine(this.itemTracked.Description + " is equipped by "+ this.whoEquipped.Name);
        }

        public void UnEquip(LivingBeing lb)
        {
            _isEquipped = false;
            whoEquipped = null;
            lb.statistics.RemoveBonus(statisModifier.StatisticDiffToApply);
           // Console.WriteLine(this.itemTracked.Description + " is desequipped");
        }

        public bool IsEquipped()
        {
            return _isEquipped;
        }
    }
}
