namespace Crawler.Cells
{
    using Components.Actions.Implementation;
    using Components.Others.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Water : Cell
    {
        public Water(GameEngine game, Vector2 p)
            : base(game, p, new BasicFlyingWalkable(), new BasicVoidActivable(), new InactiveEnterExit(), "sprite//water")
        {
        }
    }
}
