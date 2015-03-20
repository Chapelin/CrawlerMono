using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Item : MapDrawableComponent
    {
        public Item(Game1 game, Vector2 positionCell, Camera c,SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
        }
    }
}
