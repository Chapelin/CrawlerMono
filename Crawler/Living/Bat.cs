using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Living
{
    public class Bat : LivingBeing
    {
        public Bat(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb) : base(game, positionCell, c, sb)
        {
            this.sprite = this.Game.Content.Load<Texture2D>("sprite\\bat");
        }
    }
}
