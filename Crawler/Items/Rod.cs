namespace Crawler.Items
{
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Rod : Equipable
    {
        public Rod(GameEngine game, Vector2 positionCell)
            : base(game, positionCell,  "sprite\\rod")
        {
            this._description = "A beautiful rod !";
        }

    }
}
