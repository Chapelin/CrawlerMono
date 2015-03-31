using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Human : LivingBeing
    {
        public Human(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
            this.sprite = game.Content.Load<Texture2D>("sprite//human");
            this.z = 0F;
            this.statistics = new Statistics();
            this.statistics.FOV = 5;
            this.statistics.Speed = 10;
            this.Name = "Human";
            this.traits = Traits.Walking;
        }
    }
}
