namespace Crawler.Components.Others
{
    using Crawler.GameObjects.Living;

    public interface IEnterExitComponent
    {
        void Entering(LivingBeing lb);

        void Exiting(LivingBeing lb);
    }
}
