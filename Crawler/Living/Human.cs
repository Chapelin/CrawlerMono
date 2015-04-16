namespace Crawler.Living
{
    using Crawler.Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Human : LivingBeing
    {
        public Human(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb, "sprite//human")
        {
            this.z = 0F;
            this.statistics.BasicStatistics.FOV = 5;
            this.statistics.BasicStatistics.Speed = 10;
            this.Name = "Human";
            this.traits = Traits.Walking;
        }
    }
}
