namespace Crawler.Components.Others.Implementation
{
    using Crawler.Living;

    public class BasicFlyingWalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return lb.traits.HasFlag(Traits.Flying);
        }
    }
}
