using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Floor : Cell
    {
        public Floor(Game1 game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb)
        {
            this.IsWalkable = true;
            sprite = game.Content.Load<Texture2D>("sprite\\floor");
        }
    }
}
