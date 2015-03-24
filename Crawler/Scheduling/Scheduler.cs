﻿using System;
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

        public List<LivingBeing> NextPlaying()
        {
            var listPlayable = this.GetListOfPlayable(listOfBeing, TURN_TREESHOLD);
            if (!listPlayable.Any())
            {
                this.CurrentTurn++;
                this.TickList();
                listPlayable = this.GetListOfPlayable(listOfBeing, TURN_TREESHOLD);
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
            this.listOfBeing.ForEach(x => x.Tick());
        }





    }
}
