namespace Crawler.Components.ItemRelated.Implementation
{
    using Crawler.GameObjects.Living;

    public class StatisticModifierFOv : IStatisticsModifierComponent
    {
        public Statistics StatisticDiffToApply { get; set; }

        public StatisticModifierFOv()
        {
            this.StatisticDiffToApply = new Statistics();
            this.StatisticDiffToApply.FOV = 3;
            this.StatisticDiffToApply.Speed = -5;
        }
    }
}
