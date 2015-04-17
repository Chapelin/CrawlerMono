namespace Crawler.Components.Others.Implementation
{
    using Living;

    class BasicFlyingWalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return lb.traits.HasFlag(Traits.Flying);
        }
    }
}
