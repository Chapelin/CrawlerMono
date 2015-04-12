using Crawler.Components.Implementation;

namespace Crawler.Cells
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Upstair : Cell
    {
        public Upstair(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb, new BasicFloorWalkable(), new BasicVoidActivable())
        {
            sprite = game.Content.Load<Texture2D>("sprite//upstair");
        }
    }
}
