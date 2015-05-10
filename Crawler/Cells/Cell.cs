namespace Crawler.Cells
{
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Components.Actions;
    using Crawler.Components.Others;
    using Crawler.Engine;
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class Cell : MapComponent
    {
        private readonly IEnterExitComponent eeComponent;

        private readonly IWalkable walkableComponent;

        private readonly IActivableComponent ac;

        public bool IsWalkable(LivingBeing lv)
        {
            return this.walkableComponent.IsWalkable(lv);
        }

        public Cell(GameEngine game, Vector2 p, IWalkable w, IActivableComponent ac, IEnterExitComponent ee, string spriteName)
            : base(p)
        {
            this.walkableComponent = w;
            this.ac = ac;
            this.eeComponent = ee;
            this.AttachDrawingComponant(game,spriteName,1F);

        }

        public bool IsActivable(LivingBeing lb)
        {
            return this.ac.Activables(lb).Any();
        }

        public List<ActionDoable> PossibleActions(LivingBeing lb)
        {
            return this.ac.Activables(lb);
        }

        public void OnEnter(LivingBeing lb)
        {
            this.eeComponent.Entering(lb);
            this.Register(lb);
        }

        private void Register(LivingBeing lb)
        {
            if (this.IsActivable(lb))
                BlackBoard.Pool.Register(lb, this.PossibleActions(lb));
        }

        public void OnExit(LivingBeing lb)
        {
            this.eeComponent.Exiting(lb);
            this.UnRegister(lb);
        }

        private void UnRegister(LivingBeing lb)
        {
            if(this.IsActivable(lb))
                BlackBoard.Pool.UnRegister(lb,this.PossibleActions(lb));
        }
    }
}
