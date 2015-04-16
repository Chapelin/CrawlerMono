using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Living
{
    public class FullStatistics : Statistics
    {
        public Statistics BasicStatistics { get; set; }

        public Statistics AddedStatistics { get; set; }

        public int FOV
        {
            get
            {
                return this.BasicStatistics.FOV + this.AddedStatistics.FOV;
            }
        }


        public int Speed
        {
            get
            {
                return this.BasicStatistics.Speed + this.AddedStatistics.Speed;
            }
        }


        public FullStatistics(Statistics baseic)
        {
            this.BasicStatistics = baseic;
            this.AddedStatistics = new Statistics();
        }

        public void ApplyBonus(Statistics s)
        {
            this.AddedStatistics += s;
        }

        public void RemoveBonus(Statistics s)
        {
            this.AddedStatistics -= s;
        }


    }
}
