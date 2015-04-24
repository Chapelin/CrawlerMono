namespace Crawler.Cells
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.Others.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Water : Cell
    {
        public Water(GameEngine game, Vector2 p)
            : base(game, p, new BasicFlyingWalkable(), new BasicVoidActivable(), new InactiveEnterExit(), "sprite//water")
        {
            this._description = "A small pond.";
        }
    }
}
