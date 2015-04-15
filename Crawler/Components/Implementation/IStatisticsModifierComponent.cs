using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Components.Implementation
{
    using Crawler.Living;

    public interface IStatisticsModifierComponent
    {
        Statistics StatisticDiffToApply { get; set; }
    }
}
