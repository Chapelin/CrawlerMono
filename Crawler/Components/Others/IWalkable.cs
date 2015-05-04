namespace Crawler.Components.Others
{
    using Crawler.GameObjects.Living;

    public interface IWalkable
    {
        bool IsWalkable(LivingBeing lb);

    }
}
