namespace Crawler.Components.Others.Implementation
{
    using Crawler.GameObjects.Living;

    public class BasicFloorWalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return true;
        }
    }
}
