using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.Cells
{
    using Crawler.Living;

    public class Wall : Cell
    {
        public Wall(Game1 game, Vector2 p, Camera c, SpriteBatch sb)
            : base(game, p, c, sb)
        {
            
            this.sprite = game.Content.Load<Texture2D>("sprite\\wall");
        }

        public override bool IsWalkable(LivingBeing lv)
        {
            return false;
        }
    }
}
