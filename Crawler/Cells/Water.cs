using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Cells
{
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Water : Cell
    {
        public Water(Game1 game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb)
        {
        }

        public override bool IsWalkable(LivingBeing lv)
        {
            return lv.traits.HasFlag(Traits.Flying);
        }
    }
}
