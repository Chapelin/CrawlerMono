using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class BasicFloorWalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return true;
        }
    }
}
