namespace Crawler.GameObjects.Items
{
    using Crawler.Components.ItemRelated.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class Torso : Equipable
    {
        public Torso(GameEngine game, Vector2 positionCell)
            : base(game, positionCell, new BasicEquipableItem(new StatisticModifierFOv()), "sprite\\torso")
        {
            this._description = "An armor.";
        }

    }
}
