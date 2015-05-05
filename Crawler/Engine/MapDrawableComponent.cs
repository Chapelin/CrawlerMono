namespace Crawler.Engine
{
    using System;
    using System.Collections.Generic;

    using Crawler.Cells;
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class MapDrawableComponent : DrawableGameComponent
    {

        protected DrawingComponant drawing;
        protected new GameEngine Game;
        public Vector2 positionCell;

        internal Color VisitedColor = new Color(125, 125, 125);

        internal string _description;
        public string Description { get { return this._description; } }

        public List<Guid> SeenBy;

        public MapDrawableComponent(GameEngine game, Vector2 positionCell, string spriteName)
            : base(game)
        {
            this.positionCell = positionCell;
            this.drawing = new DrawingComponant(game, spriteName, 0.5F);
            this.Game = game;
            this.SeenBy = new List<Guid>();
        }

        public override void Draw(GameTime gameTime)
        {
            this.drawing.Draw(this.positionCell);
            base.Draw(gameTime);
        }

        public virtual void SetColorToUse(Visibility cv)
        {
            if (cv == Visibility.Unvisited)
            {
                this.drawing.ColorToUse = Color.Black;
            }
            else if (cv == Visibility.Visited)
            {
                this.drawing.ColorToUse = this.VisitedColor;
            }
            else
            {
                this.drawing.ColorToUse = Color.White;
            }
        }


        public virtual bool BlockVisibility(LivingBeing lb)
        {
            return false;
        }
    }
}
