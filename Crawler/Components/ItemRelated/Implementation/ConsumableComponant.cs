namespace Crawler.Components.ItemRelated.Implementation
{
    using Living;

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
