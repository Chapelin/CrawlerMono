namespace Crawler.GameObjects.Living
{
    using Crawler.Components.IA.Implementations;
    using Crawler.Components.Scheduling.Implementation;
    using Crawler.Engine;
    using Crawler.UI;

    using Microsoft.Xna.Framework;

    public class Human : LivingBeing
    {
        public Human(GameEngine game, Vector2 positionCell)
            : base(game, positionCell, "sprite//human",  new HumanPlayerIntelligence(), new SchedulableComponant())
        {
            this.Statistics.BasicStatistics.FOV = 5;
            this.Statistics.BasicStatistics.Speed = 10;
            this._description = "Human";
            this.Traits = Traits.Walking;
            this.Statistics.BasicStatistics.Intelligence = 4;
            this.Statistics.BasicStatistics.PV = 10;
            this.Statistics.BasicStatistics.Force = 4;
        }
    }
}
