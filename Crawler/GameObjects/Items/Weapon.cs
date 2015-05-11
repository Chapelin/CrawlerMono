namespace Crawler.GameObjects.Items
{
    using Crawler.Engine;
    using Crawler.GameObjects.Living;
    using Microsoft.Xna.Framework;


    public abstract class Weapon : Equipable
    {
        public Weapon(Vector2 positionCell) : base( positionCell)
        {
        }

        public abstract int CalculateOutputDamage(LivingBeing attacker);
    }
}
