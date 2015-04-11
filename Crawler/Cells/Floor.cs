using Crawler.Components.Implementation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    public class Floor : Cell
    {
     

        public Floor(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb, new BasicFloorWalkable())
        {
            sprite = game.Content.Load<Texture2D>("sprite\\floor");
        }
    }
}
