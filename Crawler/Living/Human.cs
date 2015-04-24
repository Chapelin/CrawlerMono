using Crawler.UI;

namespace Crawler.Living
{
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Human : LivingBeing
    {
        public Human(GameEngine game, Vector2 positionCell, ILogPrinter lp)
            : base(game, positionCell, "sprite//human", lp)
        {
            this.statistics.BasicStatistics.FOV = 5;
            this.statistics.BasicStatistics.Speed = 10;
            this._description = "Human";
            this.traits = Traits.Walking;
        }
    }
}
