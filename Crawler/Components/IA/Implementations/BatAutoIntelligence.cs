using System;

namespace Crawler.Components.IA.Implementations
{
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class BatAutoIntelligence : IIntelligenceComponant
    {

        public BatAutoIntelligence()
        {
            IsUserControlled = false;
        }

        public void AutoPlay(LivingBeing lb)
        {
            var Rrnd = new Random();
            var ca = Rrnd.Next(9);
            var dep = new Vector2(0, 0);
            switch (ca)
            {
                case 0:
                    dep = new Vector2(0, 1);
                    break;
                case 1:
                    dep = new Vector2(1, 0);
                    break;
                case 2:
                    dep = new Vector2(-1, 0);
                    break;
                case 3:
                    dep = new Vector2(0, -1);
                    break;

            }

            lb.positionCell += dep;
        }

        public bool IsUserControlled { get; set; }
    }
}
