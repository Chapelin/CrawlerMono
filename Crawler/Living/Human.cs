namespace Crawler
{
    using Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Human : LivingBeing
    {
        public Human(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
            sprite = game.Content.Load<Texture2D>("sprite//human");
            z = 0F;
            statistics = new Statistics();
            statistics.FOV = 5;
            statistics.Speed = 10;
            Name = "Human";
            traits = Traits.Walking;
        }
    }
}
