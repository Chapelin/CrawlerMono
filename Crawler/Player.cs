using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Player : DrawableGameComponent
    {
        private Texture2D sprite;
        private SpriteBatch sb;
        public Vector2 positionCell;

        private Camera camera;
        public Player(Game game, Vector2 positionCell, Camera c)
            : base(game)
        {
            this.sprite = game.Content.Load<Texture2D>("sprite//player");
            this.positionCell = positionCell;
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
