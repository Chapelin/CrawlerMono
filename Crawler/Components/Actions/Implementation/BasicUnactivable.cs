namespace Crawler.Components.Actions.Implementation
{
    using System.Collections.Generic;

    using Crawler.Living;

    public class BasicUnactivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
           return new List<ActionDoable>();
        }
    }
}
