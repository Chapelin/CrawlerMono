namespace Crawler.Living
{
    using System;
    using System.Security.Cryptography;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Bat : LivingBeing
    {
        public Bat(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb) : base(game, positionCell, c, sb)
        {
            this.sprite = this.Game.Content.Load<Texture2D>("sprite\\bat");
            this.statistics = new Statistics();
            this.statistics.Speed = 10;
            this.statistics.FOV = 2;
            this.IsUserControlled = false;
            this.Name = "Bat";
            this.traits = Traits.Flying;
            ;
        }

        public override void AutoPlay()
        {
            var Rrnd = new Random();
            var ca = Rrnd.Next(9);
            var dep = new Vector2(0, 0);
            switch (ca)
            {
                case 0 :
                    dep = new Vector2(0,1);
                    break;
                case 1 : 
                    dep = new Vector2(1,0);
                    break;
                case 2 : 
                    dep = new Vector2(-1,0);
                    break;
                case  3 :
                    dep = new Vector2(0,-1);
                    break;

            }
            this.positionCell += dep;
            base.AutoPlay();
        }
    }
}
