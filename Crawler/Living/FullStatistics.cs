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
                return BasicStatistics.FOV + AddedStatistics.FOV;
            }
        }


        public int Speed
        {
            get
            {
                return BasicStatistics.Speed + AddedStatistics.Speed;
            }
        }


        public FullStatistics(Statistics baseic)
        {
            BasicStatistics = baseic;
            AddedStatistics = new Statistics();
        }

        public void ApplyBonus(Statistics s)
        {
            AddedStatistics += s;
        }

        public void RemoveBonus(Statistics s)
        {
            AddedStatistics -= s;
        }


    }
}
