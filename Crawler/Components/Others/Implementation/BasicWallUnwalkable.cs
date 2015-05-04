namespace Crawler.Components.Others.Implementation
{
    using Crawler.GameObjects.Living;

    public class BasicWallUnwalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return false;
        }
    }
}
