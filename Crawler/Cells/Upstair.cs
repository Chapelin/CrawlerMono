namespace Crawler.Cells
{
    using Components.Actions.Implementation;
    using Components.Others.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;

    public class Upstair : Cell
    {
        public Upstair(GameEngine game, Vector2 p)
            : base(game, p,  new BasicFloorWalkable(), new UpstairActivable(),new MessagingEnterExit(),  "sprite//upstair")
        {
            this._description = "A stair going up to the sky";
        }
    }
}
