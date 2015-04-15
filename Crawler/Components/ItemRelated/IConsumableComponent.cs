using Crawler.Living;

namespace Crawler.Components
{
    public interface IConsumableComponent
    {
        bool CanConsume(LivingBeing lb);

        void Consume(LivingBeing lb);

    }
}
