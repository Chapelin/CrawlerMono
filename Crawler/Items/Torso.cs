namespace Crawler.Items
{
    using Crawler.Components.ItemRelated.Implementation;
    using Crawler.Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Torso : Equipable
    {
        public Torso(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb,new BasicEquipableItem(new StatisticModifierFOv()))
        {
            this.sprite = game.Content.Load<Texture2D>("sprite\\torso");
        }

        public override string Description
        {
            get
            {
                return "An armor";
            }
        }
    }
}
