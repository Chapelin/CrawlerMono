using System.Collections.Generic;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class BasicVoidActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            return new List<ActionDoable>();
        }
    }
}
