using System;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
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
    }
}
