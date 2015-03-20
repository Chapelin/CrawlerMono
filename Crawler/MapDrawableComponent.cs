using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MapDrawableComponent : DrawableGameComponent
    {
        protected Texture2D sprite;

        protected Camera camera;
        protected Game1 Game;
        protected SpriteBatch sb;
        public Vector2 positionCell;


        public MapDrawableComponent(Game1 game, Vector2 positionCell, Camera c)
            : base(game)
        {
            this.positionCell = positionCell;
            this.camera = c;
            this.sb = new SpriteBatch(game.GraphicsDevice);
            this.Game = game;
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
