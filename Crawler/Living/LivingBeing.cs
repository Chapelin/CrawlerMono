using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Living
{
    public class LivingBeing : MapDrawableComponent
    {
        public Statistics statistics;

        public List<Item.Item> Inventory; 

        public LivingBeing(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb) : base(game, positionCell, c, sb)
        {
        }
    }
}
