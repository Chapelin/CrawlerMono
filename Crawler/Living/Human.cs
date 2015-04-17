using Crawler.UI;

namespace Crawler.Living
{
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Human : LivingBeing
    {
        public Human(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb, ILogPrinter lp)
            : base(game, positionCell, c, sb, "sprite//human", lp)
        {
            z = 0F;
            statistics.BasicStatistics.FOV = 5;
            statistics.BasicStatistics.Speed = 10;
            Name = "Human";
            traits = Traits.Walking;
        }
    }
}
