namespace Crawler.Cells
{
    using Components.Actions.Implementation;
    using Components.Others.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;

    public class Downstair : Cell
    {
        public Downstair(GameEngine game, Vector2 p)
            : base(game, p,  new BasicFloorWalkable(), new DownstaireActivable(),new MessagingEnterExit(),  "sprite\\downstair")
        {
        }


    }
}
