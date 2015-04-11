using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class BasicVoidActivable : IActivableComponent
    {
        public List<Action> Activables(LivingBeing lb)
        {
            return new List<Action>();
        }
    }
}
