namespace Crawler.Components.Actions.Implementation
{
    using System.Collections.Generic;

    using Crawler.GameObjects.Living;

    public class BasicVoidActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            return new List<ActionDoable>();
        }
    }
}
