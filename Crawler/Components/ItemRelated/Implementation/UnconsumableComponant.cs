using System;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class UnconsumableComponant : IConsumableComponent
    {
        public bool CanConsume(LivingBeing lb)
        {
            return false;
        }

        public void Consume(LivingBeing lb)
        {
            throw new NotImplementedException();
        }
    }
}
