using Crawler.Components.Implementation;

namespace Crawler.Cells
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Downstair : Cell
    {
        public Downstair(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb, new BasicFloorWalkable(), new DownstaireActivable())
        {
            sprite = game.Content.Load<Texture2D>("sprite\\downstair");
        }


    }
}
