using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Components.Implementation;

namespace Crawler.Cells
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Water : Cell
    {
        public Water(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb, new BasicFlyingWalkable())
        {
        }
    }
}
