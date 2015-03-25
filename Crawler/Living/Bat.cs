namespace Crawler.Living
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bat : LivingBeing
    {
        public Bat(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb) : base(game, positionCell, c, sb)
        {
            this.sprite = this.Game.Content.Load<Texture2D>("sprite\\bat");
            this.statistics = new Statistics();
            this.statistics.Speed = 10;
            this.IsUserControlled = false;
            this.Name = "Bat";
        }
    }
}
