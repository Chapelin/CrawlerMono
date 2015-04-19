namespace Crawler.Input
{
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class MouseTargeter : DrawableGameComponent
    {
        private new GameEngine Game;

        private Camera c;

        private Point pxCurrentPos;

        private bool showTargetSprite;
        private Vector2 pxTargetSpriteOrigin;

        private SpriteBatch sb;

        public Vector2 CurrentCellTargeted;
        private Texture2D targetTexture;

        public MouseTargeter(GameEngine game, Camera c, SpriteBatch sb)
            : base(game)
        {
            this.c = c;
            pxCurrentPos = Point.Zero;
            pxTargetSpriteOrigin = Vector2.Zero;
            this.sb = sb;
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
                var tempTargetCell = c.GetCellAtPosition(pxCurrentPos);
                if (CurrentCellTargeted != tempTargetCell)
                {
                    CurrentCellTargeted = tempTargetCell;
                    showTargetSprite = c.IsCellOnCamera(CurrentCellTargeted);
                    if (showTargetSprite)
                    {
                        pxTargetSpriteOrigin = c.GetPixelPositionOriginOfCell(CurrentCellTargeted);
                    }

                    Game.IsMouseVisible = !showTargetSprite;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (showTargetSprite)
            {
                
                sb.Draw(targetTexture, pxTargetSpriteOrigin, Color.White);
            }
            base.Draw(gameTime);
        }
    }
}
