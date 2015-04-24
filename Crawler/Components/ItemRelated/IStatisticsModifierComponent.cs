namespace Crawler.Components.ItemRelated
{
    using Crawler.Living;

    public interface IStatisticsModifierComponent
    {
        Statistics StatisticDiffToApply { get; set; }
    }
}
