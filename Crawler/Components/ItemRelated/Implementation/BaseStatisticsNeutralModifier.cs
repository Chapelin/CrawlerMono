namespace Crawler.Components.ItemRelated.Implementation
{
    using Crawler.GameObjects.Living;

    public class BaseStatisticsNeutralModifier : IStatisticsModifierComponent
    {
        public Statistics StatisticDiffToApply { get; set; }

        public BaseStatisticsNeutralModifier()
        {
            this.StatisticDiffToApply = new Statistics();
        }
    }
}
