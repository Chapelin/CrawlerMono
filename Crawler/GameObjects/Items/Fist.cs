using Crawler.Engine;
using Crawler.GameObjects.Living;
using Microsoft.Xna.Framework;

namespace Crawler.GameObjects.Items
{
    public class Fist : Weapon
    {
        public Fist(GameEngine game, Vector2 positionCell, string spriteName) : base(game, positionCell, spriteName)
        {
        }

        public override int CalculateOutputDamage(LivingBeing attacker)
        {
            return 1;
        }
    }
}
