using Crawler.Components.Implementation;

namespace Crawler.Items
{
    using Crawler.Components;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Equipable : Item
    {

        public Equipable(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb, IEquipableComponent ec)
            : base(game, positionCell, c, sb, ec, new UnconsumableComponant(),new BasicUnactivable())
        {
        }

        public Equipable(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb, new BasicEquipableItem(new BaseStatisticsNeutralModifier()), new UnconsumableComponant(), new BasicUnactivable())
        {
        }
    }
}
