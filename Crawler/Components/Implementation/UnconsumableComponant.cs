using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Living;

namespace Crawler.Components.Implementation
{
    public class UnconsumableComponant : IConsumableComponent
    {
        public bool CanConsume(LivingBeing lb)
        {
            return false;
        }

        public void Consume(LivingBeing lb)
        {
            throw new NotImplementedException();
        }
    }
}
