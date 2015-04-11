using System;
using System.Collections.Generic;
using System.Linq;
using Crawler.Components;
using Crawler.Living;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    public class Cell : MapDrawableComponent
    {

        private readonly IWalkable walkableComponent;

        private readonly IActivableComponent ac;
      
        public bool IsWalkable(LivingBeing lv)
        {
            return walkableComponent.IsWalkable(lv);
        }

        public Cell(GameEngine game, Vector2 p, Camera c, SpriteBatch s, IWalkable w, IActivableComponent ac)
            : base(game, p, c, s)
        {
            this.z = 1F;
            this.walkableComponent = w;
            this.ac = ac;

        }

        public bool IsActivable(LivingBeing lb)
        {
            return this.ac.Activables(lb).Any();
        }

        public List<ActionDoable> PossibleActions(LivingBeing lb)
        {
            return this.ac.Activables(lb);
        }

    }
}
