namespace Crawler.Components.ItemRelated.Implementation
{
    using Crawler.Living;

    public class ConsumableComponant : IConsumableComponent
    {
        public bool CanConsume(LivingBeing lb)
        {
            return true;
        }

        public void Consume(LivingBeing lb)
        {
            // do some stuff
        }
    }
}
