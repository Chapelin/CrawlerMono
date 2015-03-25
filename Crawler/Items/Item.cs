namespace Crawler.Items
{
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Item : MapDrawableComponent
    {
        public Item(Game1 game, Vector2 positionCell, Camera c,SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
        }

        public virtual bool CanEquip(LivingBeing lb)
        {
            return true;
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
