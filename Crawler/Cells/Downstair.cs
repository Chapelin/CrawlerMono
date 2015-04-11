using Crawler.Components.Implementation;

namespace Crawler.Cells
{
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Downstair : Cell
    {
        public Downstair(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb, new BasicFloorWalkable())
        {
            sprite = game.Content.Load<Texture2D>("sprite\\downstair");
        }

        public override bool IsActivable(LivingBeing lb)
        {
            return lb.IsUserControlled;
        }
    }
}
