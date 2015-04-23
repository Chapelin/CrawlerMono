namespace Crawler.Components.Actions.Implementation
{
    using System.Collections.Generic;

    using Living;

    public class DownstaireActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            var result = new List<ActionDoable>();
            if (lb.IsUserControlled)
            {
                ActionDoable act = new ActionDoable
                                       {
                                           ActionName = "Go down",
                                           ActionActivity = delegate
                                               {
                                                   var currentLb = lb;
                                                   currentLb.GoMapDown();
                                               }
                                       };
                result.Add(act);
            }

            return result;
        }
    }
}
