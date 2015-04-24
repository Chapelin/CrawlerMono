namespace Crawler.Items
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.ItemRelated;
    using Crawler.Components.ItemRelated.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Equipable : Item
    {

        public Equipable(GameEngine game, Vector2 positionCell, IEquipableComponent ec, string spriteName)
            : base(game, positionCell,  ec, new UnconsumableComponant(), new BasicUnactivable(), spriteName)
        {
        }

        public Equipable(GameEngine game, Vector2 positionCell, string spriteName)
            : base(game, positionCell, new BasicEquipableItem(new BaseStatisticsNeutralModifier()), new UnconsumableComponant(), new BasicUnactivable(), spriteName)
        {
        }
    }
}
