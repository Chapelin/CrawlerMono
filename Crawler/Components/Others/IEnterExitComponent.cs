using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.Components.Others
{
    using Living;

    public interface IEnterExitComponent
    {
        void Entering(LivingBeing lb);

        void Exiting(LivingBeing lb);
    }
}
