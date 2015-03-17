using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Player : DrawableGameComponent
    {
        private Texture2D sprite;
        private SpriteBatch sb;
        public Point positionCell;
        public Point CameraOffset;
        public Player(Game game, Point positionCell)
            : base(game)
        {
            this.sprite = game.Content.Load<Texture2D>("sprite//player");
            this.positionCell = positionCell;
            this.sb = new SpriteBatch(game.GraphicsDevice);
            this.CameraOffset = new Point(0,0);
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
            var vec = Vector2.Zero;
            vec.AddPoint(this.CameraOffset);
            vec.AddPoint(this.positionCell);
            vec *= 32; //magic : sprite size
            return vec;
        }
    }
}
