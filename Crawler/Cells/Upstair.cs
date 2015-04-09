namespace Crawler.Cells
{
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Upstair : Cell
    {
        public Upstair(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb)
        {
            this.sprite = game.Content.Load<Texture2D>("sprite//upstair");
        }

        public override bool IsWalkable(LivingBeing lb)
        {
            return true;
        }

        public override bool IsActivable(LivingBeing lb)
        {
            return lb.IsUserControlled;
        }
    }
}
