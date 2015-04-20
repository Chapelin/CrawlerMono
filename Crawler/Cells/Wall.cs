using Microsoft.Xna.Framework;

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
            _description = "A wall made of rock";
        }


        public override bool BlockVisibility(LivingBeing lb)
        {
            return true;
        }
    }
}
