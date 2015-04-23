namespace Crawler.Components.Actions.Implementation
{
    using System.Collections.Generic;

    using Living;

    using Microsoft.Xna.Framework.Input;

    public class DownstaireActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            var result = new List<ActionDoable>();
            if (lb.IsUserControlled)
            {
                ActionDoable act = new ActionDoable
                                       {
                                           Name = "Go down",
                                           Activity = delegate
                                               {
                                                   var currentLb = lb;
                                                   currentLb.GoMapDown();
                                               },
                                           Bind = new Keys[]{Keys.LeftShift, Keys.D}
                                       };
                result.Add(act);
            }

            return result;
        }
    }
}
