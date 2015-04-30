namespace Crawler.Components.IA.Implementations
{
    using System;

    using Crawler.Living;

    public class HumanPlayerIntelligence : IIntelligenceComponant
    {

        public HumanPlayerIntelligence()
        {
            this.IsUserControlled = true;
        }
        public void AutoPlay(LivingBeing lb)
        {
            Console.WriteLine("No autoplay");
        }

        public bool IsUserControlled { get; set; }
    }
}
