using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class BasicWallUnwalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return false;
        }
    }
}
