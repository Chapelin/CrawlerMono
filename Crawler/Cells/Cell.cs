using Crawler.Living;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    public class Cell : MapDrawableComponent
    {
        public bool IsWalkable { get; set; }

        public Cell(Game1 game, Vector2 p,Camera c, SpriteBatch sb)
            : base(game,p,c, sb)
        {
            this.z = 1F;
        }

        public void OnEnter(LivingBeing p)
        {
            
        }

        public void OnExit(LivingBeing p)
        {
            
        }


    }
}
