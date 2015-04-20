namespace Crawler.Cells
{
    using System.Collections.Generic;
    using System.Linq;

    using Components.Actions;
    using Components.Others;
    using Engine;
    using Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Cell : MapDrawableComponent
    {
        private readonly IEnterExitComponent eeComponent;

        private readonly IWalkable walkableComponent;

        private readonly IActivableComponent ac;

        public bool IsWalkable(LivingBeing lv)
        {
            return walkableComponent.IsWalkable(lv);
        }

        public Cell(GameEngine game, Vector2 p,  IWalkable w, IActivableComponent ac, IEnterExitComponent ee, string spriteName)
            : base(game, p,  spriteName)
        {
            z = 1F;
            walkableComponent = w;
            this.ac = ac;
            eeComponent = ee;

        }

        public bool IsActivable(LivingBeing lb)
        {
            return ac.Activables(lb).Any();
        }

        public List<ActionDoable> PossibleActions(LivingBeing lb)
        {
            return ac.Activables(lb);
        }

        public void OnEnter(LivingBeing lb)
        {
            eeComponent.Entering(lb);
        }

        public void OnExit(LivingBeing lb)
        {
            eeComponent.Exiting(lb);
        }

    }
}
