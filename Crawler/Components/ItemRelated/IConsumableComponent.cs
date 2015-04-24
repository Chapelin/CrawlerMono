namespace Crawler.Components.ItemRelated
{
    using Crawler.Living;

    public interface IConsumableComponent
    {
        bool CanConsume(LivingBeing lb);

        void Consume(LivingBeing lb);

    }
}
