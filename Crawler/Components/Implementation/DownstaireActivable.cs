using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class DownstaireActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            var result = new List<ActionDoable>();
            if (lb.IsUserControlled)
            {
                ActionDoable act = new ActionDoable();
                act.ActionName = "Go down";
                act.ActionActivity = delegate
                {
                    var currentLb = lb;
                    currentLb.GoMapDown();
                };
                result.Add(act);
            }

            return result;
        }
    }
}
