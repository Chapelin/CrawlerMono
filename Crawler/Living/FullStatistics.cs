using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Living
{
    public class FullStatistics
    {
        public Statistics BasicStatistics { get; set; }

        public Statistics AddedStatistics { get; set; }

        public Statistics TotalStatistics
        {
            get
            {
                return ComputeStatistics();
            }
        }

        private Statistics ComputeStatistics()
        {
            var st = new Statistics();
            st.FOV = BasicStatistics.FOV + AddedStatistics.FOV;
            st.Speed = BasicStatistics.Speed + AddedStatistics.Speed;
            return st;
        }

        public FullStatistics()
        {
            this.BasicStatistics  = new Statistics();
            this.AddedStatistics = new Statistics();
        }

        public void ApplyBonus(Statistics s)
        {
            this.AddedStatistics+=s;
        }

        public void RemoveBonus(Statistics s)
        {
            this.AddedStatistics -= s;
        }


    }
}
