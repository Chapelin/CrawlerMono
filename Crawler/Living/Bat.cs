namespace Crawler.Living
{
    using System;

    using Crawler.Engine;
    using Crawler.UI;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bat : LivingBeing
    {
        ILogPrinter log;
        public Bat(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb, ILogPrinter printer)
            : base(game, positionCell, c, sb, "sprite\\bat")
        {
            statistics = new FullStatistics(new Statistics() { FOV = 2, Speed = 10 });
            IsUserControlled = false;
            Name = "Bat";
            traits = Traits.Flying;
            log = printer;
        }

        public override void AutoPlay()
        {
            log.AddLine("{0} autoplaying", Name);
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
            positionCell += dep;
            base.AutoPlay();
        }
    }
}
