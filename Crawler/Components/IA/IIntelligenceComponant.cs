namespace Crawler.Components.IA
{
    using Crawler.GameObjects.Living;

    public interface IIntelligenceComponant
    {
        void AutoPlay(LivingBeing lb);

        bool IsUserControlled { get; set; }
    }
}
