﻿namespace Crawler.Living
{
    using Crawler.Components.IA.Implementations;
    using Crawler.Engine;
    using Crawler.UI;

    using Microsoft.Xna.Framework;

    public class Human : LivingBeing
    {
        public Human(GameEngine game, Vector2 positionCell, ILogPrinter lp)
            : base(game, positionCell, "sprite//human", lp, new HumanPlayerIntelligence())
        {
            this.statistics.BasicStatistics.FOV = 5;
            this.statistics.BasicStatistics.Speed = 10;
            this._description = "Human";
            this.traits = Traits.Walking;
        }
    }
}
