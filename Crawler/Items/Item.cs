namespace Crawler.Items
{
    using Crawler.Cells;
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Item : MapDrawableComponent
    {

        public Item(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
            this.VisitedColor = new Color(125, 125, 125);
        }

        public virtual bool CanEquip(LivingBeing lb)
        {
            return false;
        }

        public virtual void Equip(LivingBeing lb)
        {

        }

        public virtual bool CanUse(LivingBeing lb)
        {
            return true;
        }

        public virtual void Use(LivingBeing lb)
        {

        }

        public virtual string Description { get; set; }

    }
}
