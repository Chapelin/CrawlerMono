namespace Crawler.Items
{
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Rod : Equipable
    {
        public Rod(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb, "sprite\\rod")
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
