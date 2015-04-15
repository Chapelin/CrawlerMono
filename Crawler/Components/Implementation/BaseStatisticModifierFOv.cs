namespace Crawler.Components.Implementation
{
    using Crawler.Living;

    public class BaseStatisticModifierFOv : IStatisticsModifierComponent
    {
        public Statistics StatisticDiffToApply { get; set; }

        public BaseStatisticModifierFOv()
        {
            this.StatisticDiffToApply = new Statistics();
            StatisticDiffToApply.FOV = 3;
            StatisticDiffToApply.Speed = -5;
        }
    }
}
