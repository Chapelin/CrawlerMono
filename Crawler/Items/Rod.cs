namespace Crawler.Items
{
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Rod : Equipable
    {
        public Rod(GameEngine game, Vector2 positionCell)
            : base(game, positionCell,  "sprite\\rod")
        {
        }

        public override string Description
        {
            get
            {
                return "A beautiful rod !";
            }
        }
    }
}
