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
        public Potion( Vector2 positionCell)
            : base( positionCell, new BasicUnequipable(), new ConsumableComponant(), new BasicVoidActivable())
        {
            this._description = "A simple potion.";
        }

    }
}
