namespace Crawler.Components.Others.Implementation
{
    using System;

    using Living;

    public class MessagingEnterExit : IEnterExitComponent
    {

        public void Entering(LivingBeing lb)
        {
            if (lb.IsUserControlled)
            {
                Console.WriteLine(lb.Name+ "  as entered.");
            }
        }

        public void Exiting(LivingBeing lb)
        {
            if (lb.IsUserControlled)
            {
                Console.WriteLine(lb.Name + " as left");
            }
        }
    }
}
