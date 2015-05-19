namespace Crawler.Components.ItemRelated
{
    using Crawler.GameObjects.Items;
    using Crawler.GameObjects.Living;

    public interface IEquipableComponent
    {
        bool CanEquip(LivingBeing lb);

        void Equip(LivingBeing lb);

        void UnEquip(LivingBeing lb);

        bool IsEquipped();

        Item.EquipementType typeOfItem { get; set; }
    }
}
