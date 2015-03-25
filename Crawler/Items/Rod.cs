namespace Crawler.Items
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Rod : Equipable
    {
        public Rod(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
            this.sprite = game.Content.Load<Texture2D>("sprite\\rod");
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
