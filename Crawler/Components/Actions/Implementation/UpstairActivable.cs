namespace Crawler.Components.Actions.Implementation
{
    using System;
    using System.Collections.Generic;

    using Living;

    public class UpstairActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            var result = new List<ActionDoable>();
            if (lb.IsUserControlled)
            {
                var ad = new ActionDoable();
                ad.ActionName = "Going upstair";
                ad.ActionActivity = delegate { var l = lb; l.GoMapUp(); }; 
            }

            return result;
            throw new NotImplementedException();
        }
    }
}
