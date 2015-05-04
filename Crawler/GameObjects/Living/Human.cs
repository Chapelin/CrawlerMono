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
            this.Statistics =
                new FullStatistics(new Statistics() {FOV = 5, Speed = 10, Intelligence = 4, PV = 10, Force = 4});
            this._description = "Human";
            this.Traits = Traits.Walking;
        }
    }
}
