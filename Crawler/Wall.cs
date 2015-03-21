using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Wall : Cell
    {
        public Wall(Game1 game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb)
        {
            this.IsWalkable = false;
            this.sprite = game.Content.Load<Texture2D>("sprite\\wall");
        }
    }
}
