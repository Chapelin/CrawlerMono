using System.Collections.Generic;
using Crawler.Living;

namespace Crawler.Components
{
    public interface IActivableComponent
    {
        List<ActionDoable> Activables(LivingBeing lb);
    }
}
