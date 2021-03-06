﻿namespace Crawler.GameObjects.Effect.Implementations
{
    using System;

    using Crawler.GameObjects.Living;

    public class LightEffect : IEffect<LivingBeing>
    {
        public LightEffect(int turn)
        {
            this.TurnToEnd = turn;
        }

        public int TurnToEnd { get; set; }

        public bool CanApply(LivingBeing lb)
        {
            return true;
        }

        public void Apply(LivingBeing lb)
        {
            lb.Statistics.AddedStatistics.FOV += 5;
        }

        public void UnApply(LivingBeing lb)
        {
            lb.Statistics.AddedStatistics.FOV -= 5;
            Console.WriteLine("Light effect finished");
        }

        public string Description
        {
            get
            {
                return string.Format("Light : fov +5 for {0} turns",this.TurnToEnd);
            }
        }
    }
}
