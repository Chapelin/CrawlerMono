using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class BasicFloorWalkable : IWalkable
    {
        public bool IsWalkable(LivingBeing lb)
        {
            return true;
        }
    }
}
