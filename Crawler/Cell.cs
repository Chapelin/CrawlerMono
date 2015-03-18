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
        public Vector2 positionCell { get; set; }

        private Camera camera;
        private SpriteBatch sb;
        private Texture2D sprite;

        public bool IsWalkable { get; set; }

        public Cell(Game game, Vector2 p, bool w, Camera c)
            : base(game)
        {
            string sprite = "sprite\\";
            this.IsWalkable = w;
            this.positionCell = p;
            sprite += (this.IsWalkable ? "floor" : "wall");
            this.sprite = game.Content.Load<Texture2D>(sprite);
            this.sb = new SpriteBatch(game.GraphicsDevice);
            this.camera = c;
        }

        public override void Draw(GameTime gameTime)
        {
            if (camera.IsOnCamera(this.positionCell))
            {
                this.sb.Begin();
                this.sb.Draw(this.sprite, camera.GetPixelPosition(this.positionCell), Color.White);
                this.sb.End();
            }

            base.Draw(gameTime);
        }
    }
}
