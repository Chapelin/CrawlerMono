namespace Crawler.Engine
{
    using System;
    using System.Collections.Generic;

    using Crawler.Cells;
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MapDrawableComponent : DrawableGameComponent
    {
        protected Texture2D sprite;

        protected new GameEngine Game;
        public Vector2 positionCell;

        internal Color colorToUse;

        protected float z;

        internal Color VisitedColor = new Color(125, 125, 125);

        internal string _description;
        public string Description { get { return this._description; } }

        public List<Guid> SeenBy;

        public MapDrawableComponent(GameEngine game, Vector2 positionCell,  string spriteName)
            : base(game)
        {
            this.positionCell = positionCell;

            this.Game = game;
            this.z = 0.5F;
            this.colorToUse = Color.White;
            this.SeenBy = new List<Guid>();
            this.sprite = this.Game.Content.Load<Texture2D>(spriteName);
        }

        public override void Draw(GameTime gameTime)
        {
            if (BlackBoard.CurrentCamera.IsCellOnCamera(this.positionCell))
            {
                BlackBoard.CurrentSpriteBatch.Draw(this.sprite, BlackBoard.CurrentCamera.GetPixelPositionOriginOfCell(this.positionCell), depth: this.z, color: this.colorToUse);
            }

            base.Draw(gameTime);
        }

        public virtual void SetColorToUse(Visibility cv)
        {
            if (cv == Visibility.Unvisited)
            {
                this.colorToUse = Color.Black;
            }
            else if (cv == Visibility.Visited)
            {
                this.colorToUse = this.VisitedColor;
            }
            else
            {
                this.colorToUse = Color.White;
            }
        }


        public virtual bool BlockVisibility(LivingBeing lb)
        {
            return false;
        }
    }
}
