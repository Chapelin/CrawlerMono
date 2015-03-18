using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Player : DrawableGameComponent
    {
        private Texture2D sprite;
        private SpriteBatch sb;
        public Vector2 positionCell;
        public Player(Game game, Vector2 positionCell)
            : base(game)
        {
            this.sprite = game.Content.Load<Texture2D>("sprite//player");
            this.positionCell = positionCell;
            this.sb = new SpriteBatch(game.GraphicsDevice);
        }



        public override void Draw(GameTime gameTime)
        {
            this.sb.Begin();
            this.sb.Draw(this.sprite, this.ProcessPixelPosition(), Color.White);
            this.sb.End();
            base.Draw(gameTime);
        }

        private Vector2 ProcessPixelPosition()
        {
            var vec = this.positionCell;
            vec *= 32; //magic : sprite size
            return vec;
        }
    }
}
