namespace Crawler.Scheduling
{
    using Crawler.Living;

    public class BeingScheduled
    {
        public LivingBeing being;

        public int Score;

        public BeingScheduled(LivingBeing being)
        {
            this.being = being;
            this.Score = 0;
        }

        public void Tick()
        {
            this.Score += this.being.statistics.Speed;
        }

        public void TakeTurn(int consumption)
        {
            this.Score -= consumption;
        }
    }
}
