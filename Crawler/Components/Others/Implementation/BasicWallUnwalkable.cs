namespace Crawler.Components.Others.Implementation
{
    using Crawler.Living;

    public class BasicWallUnwalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return false;
        }
    }
}
