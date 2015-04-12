using Crawler.Living;

namespace Crawler.Components
{
    public interface IEquipableComponent
    {
        bool CanEquip(LivingBeing lb);

        void Equip(LivingBeing lb);

        void UnEquip(LivingBeing lb);
    }
}
