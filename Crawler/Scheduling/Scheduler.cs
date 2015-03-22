using System.Collections.Generic;
using System.Linq;
using Crawler.Living;

namespace Crawler.Scheduling
{
    public class Scheduler
    {
        public List<ScheduledLiving> targets { get; set; }




        public void Add(LivingBeing lb)
        {
            var sl = new ScheduledLiving(lb);
            this.targets.Add(sl);
        }

        public LivingBeing GetNextPlayer()
        {
            var lowerSpeed = targets.Min(x => x.Being.statistics.Speed);
            var maxScore = targets.Max(y => y.Score);
            var nextPlayer = targets.First(x => x.Score == maxScore);
            nextPlayer.Tick(lowerSpeed);
            if (!targets.Any(x => x.Score > 0))
            {
                targets.ForEach(x=> x.ResetScore());
            }
            return nextPlayer.Being;
        }
    }
}
