﻿namespace Crawler.Components.Actions.Implementation
{
    using System.Collections.Generic;

    using Living;

    using Microsoft.Xna.Framework.Input;

    public class UpstairActivable : IActivableComponent
    {
        public List<ActionDoable> Activables(LivingBeing lb)
        {
            var result = new List<ActionDoable>();
            if (lb.IsUserControlled)
            {
                var ad = new ActionDoable
                             {
                                 Name = "Going upstair",
                                 Activity = delegate
                                     {
                                         var l = lb;
                                         l.GoMapUp();
                                     },
                             Bind = new Keys[]{Keys.LeftShift,
                                 Keys.U}
                             };
                result.Add(ad);
            }

            return result;
        }
    }
}
