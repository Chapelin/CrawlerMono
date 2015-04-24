namespace Crawler.Cells
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.Others.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Floor : Cell
    {

        public Floor(GameEngine game, Vector2 p )
            : base(game, p, new BasicFloorWalkable(), new BasicVoidActivable(), new InactiveEnterExit(),  "sprite\\floor")
        {
            this._description = "A simple floor.";
        }
    }
}
