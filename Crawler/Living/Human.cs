using Crawler.UI;

namespace Crawler.Living
{
    using Engine;

    using Microsoft.Xna.Framework;

    public class Human : LivingBeing
    {
        public Human(GameEngine game, Vector2 positionCell, ILogPrinter lp)
            : base(game, positionCell, "sprite//human", lp)
        {
            z = 0F;
            statistics.BasicStatistics.FOV = 5;
            statistics.BasicStatistics.Speed = 10;
            Name = "Human";
            traits = Traits.Walking;
        }
    }
}
