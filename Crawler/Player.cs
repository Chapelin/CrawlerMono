using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Player : MapDrawableComponent
    {

        public Player(Game1 game, Vector2 positionCell, Camera c)
            : base(game, positionCell, c)
        {
            this.sprite = game.Content.Load<Texture2D>("sprite//player");
        }

    }
}
