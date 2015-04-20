namespace Crawler.Items
{
    using Components.ItemRelated.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;

    public class Torso : Equipable
    {
        public Torso(GameEngine game, Vector2 positionCell)
            : base(game, positionCell, new BasicEquipableItem(new StatisticModifierFOv()), "sprite\\torso")
        {
            _description = "An armor.";
        }

    }
}
