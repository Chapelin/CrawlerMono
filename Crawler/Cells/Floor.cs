namespace Crawler.Cells
{
    using Components.Actions.Implementation;
    using Components.Others.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Floor : Cell
    {

        public Floor(GameEngine game, Vector2 p )
            : base(game, p, new BasicFloorWalkable(), new BasicVoidActivable(),new InactiveEnterExit(),  "sprite\\floor")
        {
        }
    }
}
