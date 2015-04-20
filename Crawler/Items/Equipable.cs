namespace Crawler.Items
{
    using Components;
    using Components.Actions.Implementation;
    using Components.ItemRelated;
    using Components.ItemRelated.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Equipable : Item
    {

        public Equipable(GameEngine game, Vector2 positionCell, IEquipableComponent ec, string spriteName)
            : base(game, positionCell,  ec, new UnconsumableComponant(), new BasicUnactivable(), spriteName)
        {
        }

        public Equipable(GameEngine game, Vector2 positionCell,string spriteName)
            : base(game, positionCell, new BasicEquipableItem(new BaseStatisticsNeutralModifier()), new UnconsumableComponant(), new BasicUnactivable(), spriteName)
        {
        }
    }
}
