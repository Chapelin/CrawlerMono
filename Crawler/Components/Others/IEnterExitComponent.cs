namespace Crawler.Components.Others
{
    using Crawler.Living;

    public interface IEnterExitComponent
    {
        void Entering(LivingBeing lb);

        void Exiting(LivingBeing lb);
    }
}
