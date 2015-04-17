namespace Crawler.Components.ItemRelated.Implementation
{
    using System;

    using Living;

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
