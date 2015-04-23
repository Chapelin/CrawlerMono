namespace Crawler.Components.Actions.Implementation
{
    using System.Collections.Generic;

    using Living;

    public class UpstairActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            var result = new List<ActionDoable>();
            if (lb.IsUserControlled)
            {
                var ad = new ActionDoable
                             {
                                 ActionName = "Going upstair",
                                 ActionActivity = delegate
                                     {
                                         var l = lb;
                                         l.GoMapUp();
                                     }
                             };
                result.Add(ad);
            }

            return result;
        }
    }
}
