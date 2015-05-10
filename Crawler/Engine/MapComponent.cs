namespace Crawler.Engine
{
    using System;
    using System.Collections.Generic;

    using Crawler.Cells;
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class MapComponent
    {

        protected DrawingComponant drawing;
        private Vector2 _positionCell;

        internal Color VisitedColor = new Color(125, 125, 125);

        internal string _description;
        public string Description { get { return this._description; } }

        public Vector2 PositionCell
        {
            get { return _positionCell; }
            set
            {
                _positionCell = value;
                if (this.drawing != null)
                {
                    this.drawing.position = _positionCell;
                }
            }
        }

        public List<Guid> SeenBy;

        public MapComponent(Vector2 positionCell)
        {
            this._positionCell = positionCell;
            this.SeenBy = new List<Guid>();
        }

        public void AttachDrawingComponant(GameEngine g, string spriteName, float z)
        {
            this.drawing = new DrawingComponant(g, spriteName, z);
            this.drawing.position = _positionCell;
            //RegisterDrawingComponant();
        }

        public void RemoveDrawingComponant()
        {
            if (this.drawing != null)
            {
                UnregisterDrawingComponant();
                this.drawing = null;
            }
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

        public void RegisterDrawingComponant()
        {
            if (this.drawing != null)
            {
                if (!BlackBoard.Game.Components.Contains(drawing))
                {
                    BlackBoard.Game.Components.Add(this.drawing);
                }
            }
        }

        public void UnregisterDrawingComponant()
        {
            if (this.drawing != null)
            {
                if (BlackBoard.Game.Components.Contains(this.drawing))
                {
                    BlackBoard.Game.Components.Remove(this.drawing);
                }
            }
        }

        public virtual bool BlockVisibility(LivingBeing lb)
        {
            return false;
        }
    }
}
