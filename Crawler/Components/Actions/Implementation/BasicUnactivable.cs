using System.Collections.Generic;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class BasicUnactivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
           return new List<ActionDoable>();
        }
    }
}
