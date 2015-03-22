using Crawler.Living;

namespace Crawler.Scheduling
{
    public class ScheduledLiving
    {
        public LivingBeing Being;
        public int Score;

        public ScheduledLiving(LivingBeing lb)
        {
            this.Being = lb;
            ResetScore();
        }

        public void ResetScore()
        {
            this.Score = this.Being.statistics.Speed;
        }

        public void Tick(int tick)
        {
            this.Score -= tick;
        }

    }

    
}