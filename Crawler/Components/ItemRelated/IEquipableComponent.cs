namespace Crawler.Components.ItemRelated
{
    using Crawler.Living;

    public interface IEquipableComponent
    {
        bool CanEquip(LivingBeing lb);

        void Equip(LivingBeing lb);

        void UnEquip(LivingBeing lb);

        bool IsEquipped();

    }
}
