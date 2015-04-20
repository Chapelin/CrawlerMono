namespace Crawler.Components.Others
{
    using Living;

    public interface IEnterExitComponent
    {
        void Entering(LivingBeing lb);

        void Exiting(LivingBeing lb);
    }
}
