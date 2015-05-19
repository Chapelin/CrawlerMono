using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Components.ItemRelated.Implementation
{
    using Crawler.GameObjects.Items;
    using Crawler.GameObjects.Living;

    public class WeaponOneHandedComponant : IEquipableComponent
    {

        private bool _isEquipped;

        private LivingBeing whoEquipped;

        private IStatisticsModifierComponent statisModifier;


        public WeaponOneHandedComponant(IStatisticsModifierComponent modifier)
        {
            // this.itemTracked = i;
            this.statisModifier = modifier;
            this.typeOfItem = Item.EquipementType.OneHand ;
        }


        public bool CanEquip(LivingBeing lb)
        {
            return true;
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

        public Item.EquipementType typeOfItem { get; set; }
    }
}
