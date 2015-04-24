namespace Crawler.Cells
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.Others.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Upstair : Cell
    {
        public Upstair(GameEngine game, Vector2 p)
            : base(game, p,  new BasicFloorWalkable(), new UpstairActivable(), new MessagingEnterExit(),  "sprite//upstair")
        {
            this._description = "A stair going up to the sky";
        }
    }
}
