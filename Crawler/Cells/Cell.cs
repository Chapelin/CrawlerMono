using Crawler.Living;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    using System;
    using System.Collections.Generic;

    public class Cell : MapDrawableComponent
    {
       


        public virtual bool IsWalkable(LivingBeing lv)
        {
            return true;
        }

        public Cell(Game1 game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb)
        {
            this.z = 1F;
          
        }

        public virtual void OnEnter(LivingBeing p)
        {

        }

        public virtual void OnExit(LivingBeing p)
        {

        }


       

    }

    public enum Visibility
    {
        Unvisited,
        Visited,
        InView
    }
}
