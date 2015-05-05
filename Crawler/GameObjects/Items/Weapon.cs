namespace Crawler.GameObjects.Items
{
    using Crawler.Engine;
    using Crawler.GameObjects.Living;
    using Microsoft.Xna.Framework;


    public abstract class Weapon : Equipable
    {
        public Weapon(GameEngine game, Vector2 positionCell, string spriteName) : base(game, positionCell, spriteName)
        {
        }

        public abstract int CalculateOutputDamage(LivingBeing attacker);
    }
}
