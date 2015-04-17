namespace Crawler.Components.Others.Implementation
{
    using Living;

    public class BasicFloorWalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return true;
        }
    }
}
