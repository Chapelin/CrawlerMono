namespace Crawler.GameObjects.Items
{
    using Crawler.Engine;
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class Rod : Weapon
    {
        public Rod( Vector2 positionCell)
            : base( positionCell)
        {
            this._description = "A beautiful rod !";
        }

        public override int CalculateOutputDamage(LivingBeing attacker)
        {
            return attacker.Statistics.Force;
        }
    }
}
