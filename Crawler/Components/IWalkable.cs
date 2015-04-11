using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Living;

namespace Crawler.Components
{
    public interface IWalkable
    {
        bool IsWalkable(LivingBeing lb);

    }
}
