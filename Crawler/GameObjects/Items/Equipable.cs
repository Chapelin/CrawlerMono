namespace Crawler.GameObjects.Items
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.ItemRelated;
    using Crawler.Components.ItemRelated.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Equipable : Item
    {

        public Equipable( Vector2 positionCell, IEquipableComponent ec)
            : base( positionCell,  ec, new UnconsumableComponant(), new BasicUnactivable())
        {
        }

        public Equipable(Vector2 positionCell)
            : base( positionCell, new BasicEquipableItem(new BaseStatisticsNeutralModifier()), new UnconsumableComponant(), new BasicUnactivable())
        {
        }
    }
}
