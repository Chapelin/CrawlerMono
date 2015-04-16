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

        protected Camera camera;
        protected new GameEngine Game;
        protected SpriteBatch sb;
        public Vector2 positionCell;

        internal Color colorToUse;

        protected float z;


        internal Color VisitedColor = new Color(125, 125, 125);

        public List<Guid> SeenBy;

        public MapDrawableComponent(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb, string spriteName)
            : base(game)
        {
            this.positionCell = positionCell;
            this.camera = c;
            this.sb = sb;
            this.Game = game;
            this.z = 0.5F;
            this.colorToUse = Color.White;
            this.SeenBy = new List<Guid>();
            this.sprite = Game.Content.Load<Texture2D>(spriteName);
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.camera.IsCellOnCamera(this.positionCell))
            {
                this.sb.Draw(this.sprite, this.camera.GetPixelPositionOriginOfCell(this.positionCell), depth: this.z, color: this.colorToUse);
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
