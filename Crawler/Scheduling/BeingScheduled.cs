namespace Crawler.Scheduling
{
    using Living;

    public class BeingScheduled
    {
        public LivingBeing being;

        public int Score;

        public BeingScheduled(LivingBeing being)
        {
            this.being = being;
            Score = 0;
        }

        public void Tick()
        {
            Score += being.statistics.Speed;
        }

        public void TakeTurn(int consumption)
        {
            Score -= consumption;
        }
    }
}
