using Crawler.Components;
using Crawler.Living;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    public class Cell : MapDrawableComponent
    {

        private readonly IWalkable walkableComponent;

      
        public bool IsWalkable(LivingBeing lv)
        {
            return walkableComponent.IsWalkable(lv);
        }

        public Cell(GameEngine game, Vector2 p, Camera c, SpriteBatch s, IWalkable w)
            : base(game, p, c, s)
        {
            this.z = 1F;
            this.walkableComponent = w;

        }

        public virtual void OnEnter(LivingBeing p)
        {

        }

        public virtual void OnExit(LivingBeing p)
        {

        }

        public virtual bool IsActivable(LivingBeing lb)
        {
            return false;
        }

        public virtual void Activate(LivingBeing lb)
        {
            
        }


       

    }
}
