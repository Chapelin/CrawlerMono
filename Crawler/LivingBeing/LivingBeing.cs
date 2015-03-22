using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class LivingBeing : MapDrawableComponent
    {

        public List<Item> Inventory; 

        public LivingBeing(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb) : base(game, positionCell, c, sb)
        {
        }
    }
}
