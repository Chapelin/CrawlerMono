namespace Crawler.Scheduling
{
    using System.Collections.Generic;
    using System.Linq;

    using Living;

    public class Scheduler
    {
        public int CurrentTurn { get; set; }

        private List<BeingScheduled> listOfBeing;

        public const int TURN_TREESHOLD = 10;

        private List<LivingBeing> playing;

        public LivingBeing CurrentPlaying()
        {
            if (!playing.Any())
            {
                playing = NextPlaying();
            }
            return playing.First();

        }

        public void Played()
        {
            playing.RemoveAt(0);
        }


        public Scheduler()
        {
            listOfBeing = new List<BeingScheduled>();
            CurrentTurn = 0;
            playing = new List<LivingBeing>();
        }

        public void AddABeing(LivingBeing b)
        {
            listOfBeing.Add(new BeingScheduled(b));
        }

        protected List<LivingBeing> NextPlaying()
        {
            var listPlayable = GetListOfPlayable(listOfBeing, TURN_TREESHOLD);
            if (!listPlayable.Any())
            {
                CurrentTurn++;
                TickList();
                listPlayable = GetListOfPlayable(listOfBeing, TURN_TREESHOLD);
            }
            foreach (var beingScheduled in listPlayable)
            {
                beingScheduled.TakeTurn(TURN_TREESHOLD);
            }
            return listPlayable.Select(x => x.being).ToList();

        }

        private List<BeingScheduled> GetListOfPlayable(List<BeingScheduled> listPlayable, int turnTreeshold)
        {
            return listPlayable.Where(x => x.Score >= turnTreeshold).ToList();
        }

        public void TickList()
        {
            listOfBeing.ForEach(x => x.Tick());
        }





    }
}
