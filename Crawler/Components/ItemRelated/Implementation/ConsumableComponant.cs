namespace Crawler.Components.ItemRelated.Implementation
{
    using System;

    using Living;

    public class ConsumableComponant : IConsumableComponent
    {
        public bool CanConsume(LivingBeing lb)
        {
            return true;
        }

        public void Consume(LivingBeing lb)
        {
            Console.WriteLine(lb.Description + " drank.");
            // do some stuff
        }
    }
}
