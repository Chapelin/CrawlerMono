namespace Crawler.GameObjects.Items
{
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class Fist : Weapon
    {
        public Fist( Vector2 positionCell) : base( positionCell)
        {
        }

        public override int CalculateOutputDamage(LivingBeing attacker)
        {
            return 1;
        }
    }
}
