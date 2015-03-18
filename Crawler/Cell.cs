using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Cell : DrawableGameComponent
    {
        Point positionCell { get; set; }

        private SpriteBatch sb;
        private Texture2D sprite;

        public bool IsWalkable { get; set; }

        public Cell(Game game, Point p, bool w)
            : base(game)
        {
            string sprite = "sprite\\";
            this.IsWalkable = w;
            this.positionCell = p;
            sprite += (this.IsWalkable ? "floor" : "wall");
            this.sprite = game.Content.Load<Texture2D>(sprite);
            this.sb = new SpriteBatch(game.GraphicsDevice);
        }

        public override void Draw(GameTime gameTime)
        {
            this.sb.Begin();
            this.sb.Draw(this.sprite, new Vector2(this.positionCell.X * 32, this.positionCell.Y * 32), Color.White);
            this.sb.End();
            base.Draw(gameTime);
        }
    }
}
