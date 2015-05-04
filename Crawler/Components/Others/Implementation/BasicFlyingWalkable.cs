namespace Crawler.Components.Others.Implementation
{
    using Crawler.GameObjects.Living;

    public class BasicFlyingWalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return lb.traits.HasFlag(Traits.Flying);
        }
    }
}
