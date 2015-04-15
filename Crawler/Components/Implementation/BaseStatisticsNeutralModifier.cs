using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Components.Implementation
{
    using Crawler.Living;

    public class BaseStatisticsNeutralModifier : IStatisticsModifierComponent
    {
        public Statistics StatisticDiffToApply { get; set; }

        public BaseStatisticsNeutralModifier()
        {
            this.StatisticDiffToApply = new Statistics();
        }
    }
}
