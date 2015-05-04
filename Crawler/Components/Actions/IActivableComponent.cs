namespace Crawler.Components.Actions
{
    using System.Collections.Generic;

    using Crawler.GameObjects.Living;

    public interface IActivableComponent
    {
        List<ActionDoable> Activables(LivingBeing lb);
    }
}
