namespace Crawler.Components.ItemRelated
{
    using Living;

    public interface IConsumableComponent
    {
        bool CanConsume(LivingBeing lb);

        void Consume(LivingBeing lb);

    }
}
