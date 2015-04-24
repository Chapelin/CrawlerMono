namespace Crawler.Cells
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.Others.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Downstair : Cell
    {
        public Downstair(GameEngine game, Vector2 p)
            : base(game, p,  new BasicFloorWalkable(), new DownstaireActivable(), new MessagingEnterExit(),  "sprite\\downstair")
        {
            base._description = "A stair going down.";
        }


    }
}
