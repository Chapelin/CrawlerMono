namespace Crawler.Items
{
    using System.Linq;

    using Crawler.Components.Actions;
    using Crawler.Components.ItemRelated;
    using Crawler.Engine;
    using Crawler.Living;

    using Microsoft.Xna.Framework;

    public class Item : MapDrawableComponent
    {
        protected IEquipableComponent equipableComponent;
        private IConsumableComponent cc;
        private IActivableComponent ac;
        public Item(GameEngine game, Vector2 positionCell,  IEquipableComponent ec, IConsumableComponent cc, IActivableComponent ac, string spriteName)
            : base(game, positionCell, spriteName)
        {
            this.VisitedColor = new Color(125, 125, 125);
            this.equipableComponent = ec;
            this.cc = cc;
            this.ac = ac;
        }

        public bool CanEquip(LivingBeing lb)
        {
            return this.equipableComponent.CanEquip(lb);
        }

        public void Equip(LivingBeing lb)
        {
            this.equipableComponent.Equip(lb);
        }

        public void UnEquip(LivingBeing lb)
        {
            this.equipableComponent.UnEquip(lb);
        }

        public bool CanConsume(LivingBeing lb)
        {
            return this.cc.CanConsume(lb);
        }

        public void Consume(LivingBeing lb)
        {
            this.cc.Consume(lb);
        }

        public bool CanUse(LivingBeing lb)
        {
            return this.ac.Activables(lb).Any();
        }

        public bool IsEquipped
        {
            get
            {
                return this.equipableComponent.IsEquipped();
            }
        }

    }
}
