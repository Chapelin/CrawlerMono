namespace Crawler.Cells
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.Others.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Water : Cell
    {
        public Water(GameEngine game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb, new BasicFlyingWalkable(), new BasicVoidActivable(),"sprite//water")
        {
        }
    }
}
