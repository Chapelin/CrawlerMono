using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    using Crawler.Living;

    public class Floor : Cell
    {
        public override bool IsWalkable(LivingBeing lb)
        {
            return true;
        }

        public Floor(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb)
        {
            sprite = game.Content.Load<Texture2D>("sprite\\floor");
        }
    }
}
