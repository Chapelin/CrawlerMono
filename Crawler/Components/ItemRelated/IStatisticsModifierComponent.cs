namespace Crawler.Components.ItemRelated
{
    using Living;

    public interface IStatisticsModifierComponent
    {
        Statistics StatisticDiffToApply { get; set; }
    }
}
