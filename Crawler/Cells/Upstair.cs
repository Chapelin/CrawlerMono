namespace Crawler.Cells
{
    using Components.Actions.Implementation;
    using Components.Others.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;

    public class Upstair : Cell
    {
        public Upstair(GameEngine game, Vector2 p)
            : base(game, p,  new BasicFloorWalkable(), new BasicVoidActivable(),new MessagingEnterExit(),  "sprite//upstair")
        {
        }
    }
}
