namespace Crawler.GameObjects.Effect.Implementations
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
            lb.statistics.AddedStatistics.FOV += 5;
        }

        public void UnApply(LivingBeing lb)
        {
            lb.statistics.AddedStatistics.FOV -= 5;
            Console.WriteLine("Light effect finished");
        }
    }
}
