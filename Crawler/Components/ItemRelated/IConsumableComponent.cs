namespace Crawler.Components.ItemRelated
{
    using Crawler.GameObjects.Living;

    public interface IConsumableComponent
    {
        bool CanConsume(LivingBeing lb);

        void Consume(LivingBeing lb);

    }
}
