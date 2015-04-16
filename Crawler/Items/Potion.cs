namespace Crawler.Items
{
    using Crawler.Components.Actions.Implementation;
    using Crawler.Components.ItemRelated.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The potion.
    /// </summary>
    public class Potion : Item
    {
        public Potion(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb, new BasicUnequipable(), new ConsumableComponant(), new BasicVoidActivable(), "sprite\\potion")
        {
        }

        public override string Description
        {
            get
            {
                return "Potion beurk";
            }
        }
    }
}
