namespace Crawler.GameObjects.Items
{
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class Rod : Weapon
    {
        public Rod( Vector2 positionCell)
            : base( positionCell)
        {
            this._description = "A beautiful rod !";
            this.equipableComponent.typeOfItem = EquipementType.OneHand;
        }

        public override int CalculateOutputDamage(LivingBeing attacker)
        {
            return attacker.Statistics.Force;
        }
    }
}
