namespace Crawler.Components.ItemRelated
{
    using Crawler.GameObjects.Living;

    public interface IEquipableComponent
    {
        bool CanEquip(LivingBeing lb);

        void Equip(LivingBeing lb);

        void UnEquip(LivingBeing lb);

        bool IsEquipped();

    }
}
