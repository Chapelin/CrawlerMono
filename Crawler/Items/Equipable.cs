using Crawler.Components.Implementation;

namespace Crawler.Items
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Equipable : Item
    {
        public Equipable(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb, new BasicEquipableItem(), new UnconsumableComponant(),new BasicUnactivable())
        {
        }
    }
}
