using Crawler.GameObjects.Living;

namespace Crawler.GameObjects.Items
{
    using Engine;

    using Microsoft.Xna.Framework;

    public class Rod : Weapon
    {
        public Rod(GameEngine game, Vector2 positionCell)
            : base(game, positionCell,  "sprite\\rod")
        {
            this._description = "A beautiful rod !";
        }

        public override int CalculateOutputDamage(LivingBeing attacker)
        {
            return attacker.Statistics.Force;
        }
    }
}
