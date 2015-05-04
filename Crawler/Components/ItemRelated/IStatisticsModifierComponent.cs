namespace Crawler.Components.ItemRelated
{
    using Crawler.GameObjects.Living;

    public interface IStatisticsModifierComponent
    {
        Statistics StatisticDiffToApply { get; set; }
    }
}
