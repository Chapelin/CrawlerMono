namespace Crawler.Living
{
    using System;

    using Crawler.Engine;
    using Crawler.UI;

    using Microsoft.Xna.Framework;

    public class Bat : LivingBeing
    {
        ILogPrinter log;
        public Bat(GameEngine game, Vector2 positionCell,  ILogPrinter printer)
            : base(game, positionCell, "sprite\\bat", printer)
        {
            this.statistics = new FullStatistics(new Statistics() { FOV = 2, Speed = 10 });
            this.IsUserControlled = false;
            this._description = "Bat";
            this.traits = Traits.Flying;
            this.log = printer;
        }

        public override void AutoPlay()
        {
            this.log.WriteLine("{0} autoplaying", this.Description);
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

            this.positionCell += dep;
            base.AutoPlay();
        }
    }
}
