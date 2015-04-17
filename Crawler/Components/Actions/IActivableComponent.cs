namespace Crawler.Components.Actions
{
    using System.Collections.Generic;

    using Living;

    public interface IActivableComponent
    {
        List<ActionDoable> Activables(LivingBeing lb);
    }
}
