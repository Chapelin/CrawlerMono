namespace Crawler.Components.ItemRelated.Implementation
{
    using Living;

    public class BaseStatisticsNeutralModifier : IStatisticsModifierComponent
    {
        public Statistics StatisticDiffToApply { get; set; }

        public BaseStatisticsNeutralModifier()
        {
            StatisticDiffToApply = new Statistics();
        }
    }
}
