using Crawler.Living;

namespace Crawler.Components.Implementation
{
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
