namespace Crawler.Engine
{
    using System;
    using System.Collections.Generic;

    using Cells;
    using Living;

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

        public MapDrawableComponent(GameEngine game, Vector2 positionCell,  string spriteName)
            : base(game)
        {
            this.positionCell = positionCell;
            camera = BlackBoard.CurrentCamera;
            this.sb = BlackBoard.CurrentSpriteBatch;
            Game = game;
            z = 0.5F;
            colorToUse = Color.White;
            SeenBy = new List<Guid>();
            sprite = Game.Content.Load<Texture2D>(spriteName);
        }

        public override void Draw(GameTime gameTime)
        {
            if (camera.IsCellOnCamera(positionCell))
            {
                sb.Draw(sprite, camera.GetPixelPositionOriginOfCell(positionCell), depth: z, color: colorToUse);
            }

            base.Draw(gameTime);
        }

        public virtual void SetColorToUse(Visibility cv)
        {
            if (cv == Visibility.Unvisited)
            {
                colorToUse = Color.Black;
            }
            else if (cv == Visibility.Visited)
            {
                colorToUse = VisitedColor;
            }
            else
            {
                colorToUse = Color.White;
            }
        }


        public virtual bool BlockVisibility(LivingBeing lb)
        {
            return false;
        }
    }
}
