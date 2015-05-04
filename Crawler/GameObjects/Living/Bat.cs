namespace Crawler.GameObjects.Living
{
    using Crawler.Components.IA.Implementations;
    using Crawler.Components.Scheduling.Implementation;
    using Crawler.Engine;
    using Crawler.UI;

    using Microsoft.Xna.Framework;

    public class Bat : LivingBeing
    {
        public Bat(GameEngine game, Vector2 positionCell)
            : base(game, positionCell, "sprite\\bat", new BatAutoIntelligence(), new SchedulableComponant())
        {
            this.Statistics = new FullStatistics(new Statistics() { FOV = 2, Speed = 10 });
            this._description = "Bat";
            this.Traits = Traits.Flying;
        }

    }
}
