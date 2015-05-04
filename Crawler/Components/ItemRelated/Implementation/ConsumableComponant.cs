namespace Crawler.Components.ItemRelated.Implementation
{
    using System;

    using Crawler.GameObjects.Living;

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
