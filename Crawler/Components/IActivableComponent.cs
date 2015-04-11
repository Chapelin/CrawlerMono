using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Annotations;
using Crawler.Living;

namespace Crawler.Components
{
    public interface IActivableComponent
    {
        List<Action> Activables(LivingBeing lb);
    }
}
