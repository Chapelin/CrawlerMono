namespace Crawler.Components.Implementation
{
    using Crawler.Living;

    public class StatisticModifierFOv : IStatisticsModifierComponent
    {
        public Statistics StatisticDiffToApply { get; set; }

        public StatisticModifierFOv()
        {
            this.StatisticDiffToApply = new Statistics();
            StatisticDiffToApply.FOV = 3;
            StatisticDiffToApply.Speed = -5;
        }
    }
}
