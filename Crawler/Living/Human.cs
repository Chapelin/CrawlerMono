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
            statistics.BasicStatistics.FOV = 5;
            statistics.BasicStatistics.Speed = 10;
            _description = "Human";
            traits = Traits.Walking;
        }
    }
}
