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

        protected float z;
        

        public MapDrawableComponent(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game)
        {
            this.positionCell = positionCell;
            this.camera = c;
            this.sb = sb;
            this.Game = game;
            this.z = 0.5F;
        }

        public override void Draw(GameTime gameTime)
        {
            if (camera.IsOnCamera(this.positionCell))
            {
               // this.sb.Begin(SpriteSortMode.BackToFront, null);
                //this.sb.Draw(this.sprite, camera.GetPixelPosition(this.positionCell), Color.White);
                this.sb.Draw(this.sprite, camera.GetPixelPosition(this.positionCell), depth: z);
                //this.sb.End();
            }

            base.Draw(gameTime);
        }
    }
}
