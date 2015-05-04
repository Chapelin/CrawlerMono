namespace Crawler.Components.Scheduling
{
    using Crawler.GameObjects.Living;

    public interface ISchedulable
    {
        int Score { get; set; }

        LivingBeing being { get; set; }

        void AddToSchedule(LivingBeing lb);

        void Tick();

        void TakeTurn(int consumption);

    }
}
