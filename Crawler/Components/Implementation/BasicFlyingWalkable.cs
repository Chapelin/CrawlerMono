using Crawler.Living;

namespace Crawler.Components.Implementation
{
    class BasicFlyingWalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return lb.traits.HasFlag(Traits.Flying);
        }
    }
}
