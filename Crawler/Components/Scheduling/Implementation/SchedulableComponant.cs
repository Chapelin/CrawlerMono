using Crawler.Living;

namespace Crawler.Components.Scheduling.Implementation
{
    public class SchedulableComponant : ISchedulable
    {

        public int Score { get; set; }
        public LivingBeing being { get; set; }

        public SchedulableComponant()
        {
            this.Score = 0;
        }

        public void AddToSchedule(LivingBeing lb)
        {
            this.being = lb;
            BlackBoard.Scheduler.AddABeing(this);
        }

        public void Tick()
        {
            this.Score += being.statistics.Speed;
        }

        public void TakeTurn(int consumption)
        {
            this.Score -= consumption;
        }
    }
}
