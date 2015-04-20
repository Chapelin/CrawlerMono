using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    using Components.Actions.Implementation;
    using Components.Others.Implementation;
    using Engine;

    using Living;

    public class Wall : Cell
    {
        public Wall(GameEngine game, Vector2 p)
            : base(game, p,  new BasicWallUnwalkable(), new BasicVoidActivable(),new InactiveEnterExit(),  "sprite\\wall")
        {

        }


        public override bool BlockVisibility(LivingBeing lb)
        {
            return true;
        }
    }
}
