namespace Crawler.Components.ItemRelated.Implementation
{
    using Living;

    public class StatisticModifierFOv : IStatisticsModifierComponent
    {
        public Statistics StatisticDiffToApply { get; set; }

        public StatisticModifierFOv()
        {
            StatisticDiffToApply = new Statistics();
            StatisticDiffToApply.FOV = 3;
            StatisticDiffToApply.Speed = -5;
        }
    }
}
