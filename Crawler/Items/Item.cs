namespace Crawler.Items
{
    using System.Linq;

    using Crawler.Components;
    using Crawler.Components.Actions;
    using Crawler.Components.ItemRelated;
    using Crawler.Engine;
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Item : MapDrawableComponent
    {
        protected IEquipableComponent equipableComponent;
        private IConsumableComponent cc;
        private IActivableComponent ac;
        public Item(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb, IEquipableComponent ec, IConsumableComponent cc, IActivableComponent ac, string spriteName)
            : base(game, positionCell, c, sb, spriteName)
        {
            VisitedColor = new Color(125, 125, 125);
            equipableComponent = ec;
            this.cc = cc;
            this.ac = ac;
        }

        public bool CanEquip(LivingBeing lb)
        {
            return equipableComponent.CanEquip(lb);
        }

        public void Equip(LivingBeing lb)
        {
            equipableComponent.Equip(lb);
        }

        public void UnEquip(LivingBeing lb)
        {
            equipableComponent.UnEquip(lb);
        }

        public bool CanConsume(LivingBeing lb)
        {
            return cc.CanConsume(lb);
        }

        public void Consume(LivingBeing lb)
        {
            cc.Consume(lb);
        }

        public bool CanUse(LivingBeing lb)
        {
            return ac.Activables(lb).Any();
        }

        public bool IsEquipped
        {
            get
            {
                return this.equipableComponent.IsEquipped();
            }
        }


        public virtual string Description { get; set; }

    }
}
