namespace Crawler.Components.IA
{
    using Crawler.Living;

    public interface IIntelligenceComponant
    {
        void AutoPlay(LivingBeing lb);

        bool IsUserControlled { get; set; }
    }
}
