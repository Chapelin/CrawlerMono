﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.Others.Implementation;
    using Crawler.Engine;

    using Living;

    public class Wall : Cell
    {
        public Wall(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb, new BasicWallUnwalkable(), new BasicVoidActivable(),new InactiveEnterExit(),  "sprite\\wall")
        {

        }


        public override bool BlockVisibility(LivingBeing lb)
        {
            return true;
        }
    }
}
