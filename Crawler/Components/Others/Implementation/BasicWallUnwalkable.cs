namespace Crawler.Components.Others.Implementation
{
    using Living;

    public class BasicWallUnwalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return false;
        }
    }
}
