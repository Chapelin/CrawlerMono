using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Living
{
    public class Player : LivingBeing
    {

        public Player(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
            this.sprite = game.Content.Load<Texture2D>("sprite//player");
            this.z = 0F;
        }

    }
}
