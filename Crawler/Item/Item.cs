using Crawler.Living;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Item
{
    public class Item : MapDrawableComponent
    {
        public Item(Game1 game, Vector2 positionCell, Camera c,SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
        }

        public bool CanEquip(LivingBeing lb)
        {
            return true;
        }

        public void Equip(LivingBeing lb)
        {
            
        }

        public bool CanUse(LivingBeing lb)
        {
            return true;
        }

        public void Use(LivingBeing lb)
        {
            
        }
    }
}
