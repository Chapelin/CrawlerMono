namespace Crawler.Items
{
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Equipable : Item
    {
        public Equipable(Game1 game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
        }

        public override bool CanEquip(LivingBeing lb)
        {
            return true;
        }
    }
}
