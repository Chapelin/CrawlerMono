namespace Crawler.Cells
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.Others.Implementation;
    using Crawler.Engine;
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class Wall : Cell
    {
        public Wall(GameEngine game, Vector2 p)
            : base(game, p,  new BasicWallUnwalkable(), new BasicVoidActivable(), new InactiveEnterExit(),  "sprite\\wall")
        {
            this._description = "A wall made of rock";
        }


        public override bool BlockVisibility(LivingBeing lb)
        {
            return true;
        }
    }
}
