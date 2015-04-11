using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class UpstairActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            var result = new List<ActionDoable>();
            if (lb.IsUserControlled)
            {
                var ad = new ActionDoable();
                ad.ActionName = "Going upstair";
                ad.ActionActivity = delegate { var l = lb; l.GoMapUp(); }; 
            }

            return result;
            throw new NotImplementedException();
        }
    }
}
