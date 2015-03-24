using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Scheduling
{
    using Crawler.Living;

    public class Scheduler
    {
        public int CurrentTurn { get; set; }

        private List<BeingScheduled> listOfBeing;

        public const int TURN_TREESHOLD = 10;

        public Scheduler()
        {
            this.listOfBeing = new List<BeingScheduled>();
            this.CurrentTurn = 0;

        }

        public void AddABeing(LivingBeing b)
        {
            this.listOfBeing.Add(new BeingScheduled(b));
        }

        public IEnumerable<LivingBeing> NextPlaying()
        {
            while (true)
            {
                this.CurrentTurn++;
                this.TickList();
                var listPlayable = this.GetListOfPlayable(listOfBeing, TURN_TREESHOLD);
                do
                {
                    foreach (var beingScheduled in listPlayable)
                    {
                        beingScheduled.TakeTurn(TURN_TREESHOLD);

                        yield return beingScheduled.being;
                    }

                    listPlayable = this.GetListOfPlayable(listPlayable, TURN_TREESHOLD);
                }
                while (listPlayable.Any());
            }
        }

        private IEnumerable<BeingScheduled> GetListOfPlayable(IEnumerable<BeingScheduled> listPlayable, int turnTreeshold)
        {
            return listPlayable.Where(x => x.Score >= turnTreeshold);
        }

        public void TickList()
        {
            this.listOfBeing.ForEach(x => x.Tick());
        }





    }
}
