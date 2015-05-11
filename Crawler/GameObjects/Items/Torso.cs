namespace Crawler.GameObjects.Items
{
    using Crawler.Components.ItemRelated.Implementation;

    using Microsoft.Xna.Framework;

    public class Torso : Equipable
    {
        public Torso( Vector2 positionCell)
            : base( positionCell, new BasicEquipableItem(new StatisticModifierFOv()))
        {
            this._description = "An armor.";
        }

    }
}
