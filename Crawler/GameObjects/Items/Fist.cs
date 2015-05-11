using Crawler.Engine;
using Crawler.GameObjects.Living;
using Microsoft.Xna.Framework;

namespace Crawler.GameObjects.Items
{
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
