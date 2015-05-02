using Crawler.Components.Scheduling.Implementation;

namespace Crawler.Living
{
    using Crawler.Components.IA.Implementations;
    using Crawler.Engine;
    using Crawler.UI;

    using Microsoft.Xna.Framework;

    public class Bat : LivingBeing
    {
        ILogPrinter log;
        public Bat(GameEngine game, Vector2 positionCell,  ILogPrinter printer)
            : base(game, positionCell, "sprite\\bat", printer, new BatAutoIntelligence(), new SchedulableComponant())
        {
            this.statistics = new FullStatistics(new Statistics() { FOV = 2, Speed = 10 });
            this._description = "Bat";
            this.traits = Traits.Flying;
            this.log = printer;
        }

    }
}
