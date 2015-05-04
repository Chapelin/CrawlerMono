namespace Crawler.GameObjects.Effect.Implementations
{
    using Crawler.GameObjects.Living;

    public class FastEffect : IEffect<LivingBeing>
    {
        public int TurnToEnd { get; set; }

        public FastEffect(int turntoEnd)
        {
            this.TurnToEnd = turntoEnd;
        }

        public bool CanApply(LivingBeing lb)
        {
            return true;
        }

        public void Apply(LivingBeing lb)
        {
            lb.Statistics.AddedStatistics.Speed += 5;
        }

        public void UnApply(LivingBeing lb)
        {
            lb.Statistics.AddedStatistics.Speed -= 5;
        }

        public string Description
        {
            get
            {
                return string.Format("Fast : speed +5 for {0} turns", this.TurnToEnd);
            }
        }
    }
}
