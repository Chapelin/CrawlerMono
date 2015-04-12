using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class BasicEquipableItem : IEquipableComponent
    {
        private bool IsEquipped;

        public bool CanEquip(LivingBeing lb)
        {
            return true;
        }

        public void Equip(LivingBeing lb)
        {
            ;
        }

        public void UnEquip(LivingBeing lb)
        {
            ;
        }
    }
}
