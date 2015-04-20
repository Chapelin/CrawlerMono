namespace Crawler.Items
{
    using Engine;

    using Microsoft.Xna.Framework;

    public class Rod : Equipable
    {
        public Rod(GameEngine game, Vector2 positionCell)
            : base(game, positionCell,  "sprite\\rod")
        {
            _description = "A beautiful rod !";
        }

    }
}
