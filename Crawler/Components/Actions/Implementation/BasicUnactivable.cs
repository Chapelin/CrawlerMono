namespace Crawler.Components.Actions.Implementation
{
    using System.Collections.Generic;

    using Crawler.GameObjects.Living;

    public class BasicUnactivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
           return new List<ActionDoable>();
        }
    }
}
