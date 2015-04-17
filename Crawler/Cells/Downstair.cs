namespace Crawler.Cells
{
    using Components.Actions.Implementation;
    using Components.Others.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Downstair : Cell
    {
        public Downstair(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb, new BasicFloorWalkable(), new DownstaireActivable(),new MessagingEnterExit(),  "sprite\\downstair")
        {
        }


    }
}
