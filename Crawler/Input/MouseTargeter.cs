namespace Crawler.Input
{
    using Crawler.UI;

    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MouseTargeter : DrawableGameComponent
    {
        private new GameEngine Game;


        private Point pxCurrentPos;

        private bool showTargetSprite;
        private Vector2 pxTargetSpriteOrigin;


        public Vector2 CurrentCellTargeted;
        private Texture2D targetTexture;

        public MouseTargeter(GameEngine game)
            : base(game)
        {
            pxCurrentPos = Point.Zero;
            pxTargetSpriteOrigin = Vector2.Zero;
            CurrentCellTargeted = Vector2.Zero;
            targetTexture = game.Content.Load<Texture2D>("sprite//target");
            Game = game;
        }

        public override void Update(GameTime gameTime)
        {
            var mousePosition = Mouse.GetState().Position;
            if (mousePosition != pxCurrentPos)
            {
                pxCurrentPos = mousePosition;
                var tempTargetCell = BlackBoard.CurrentCamera.GetCellAtPosition(pxCurrentPos);
                if (CurrentCellTargeted != tempTargetCell)
                {
                    CurrentCellTargeted = tempTargetCell;
                    showTargetSprite = BlackBoard.CurrentCamera.IsCellOnCamera(CurrentCellTargeted);
                    if (showTargetSprite)
                    {
                        pxTargetSpriteOrigin = BlackBoard.CurrentCamera.GetPixelPositionOriginOfCell(CurrentCellTargeted);
                    }

                    Game.IsMouseVisible = !showTargetSprite;
                    BlackBoard.CurrentMap.CurrentTargetedCell = CurrentCellTargeted;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (showTargetSprite)
            {
                
                BlackBoard.CurrentSpriteBatch.Draw(targetTexture, pxTargetSpriteOrigin, Color.White);
            }
            base.Draw(gameTime);
        }
    }
}
