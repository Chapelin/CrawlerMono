namespace Crawler.GameObjects.Items
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.ItemRelated.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// The potion.
    /// </summary>
    public class Potion : Item
    {
        public Potion(GameEngine game, Vector2 positionCell)
            : base(game, positionCell, new BasicUnequipable(), new ConsumableComponant(), new BasicVoidActivable(), "sprite\\potion")
        {
            this._description = "A simple potion.";
        }

    }
}
