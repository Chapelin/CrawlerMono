namespace Crawler.Items
{
    using Components.Actions.Implementation;
    using Components.ItemRelated.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// The potion.
    /// </summary>
    public class Potion : Item
    {
        public Potion(GameEngine game, Vector2 positionCell)
            : base(game, positionCell, new BasicUnequipable(), new ConsumableComponant(), new BasicVoidActivable(), "sprite\\potion")
        {
            _description = "A simple potion.";
        }

    }
}
