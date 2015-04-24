namespace Crawler.Input
{
    using Crawler.Engine;

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
            this.pxCurrentPos = Point.Zero;
            this.pxTargetSpriteOrigin = Vector2.Zero;
            this.CurrentCellTargeted = Vector2.Zero;
            this.targetTexture = game.Content.Load<Texture2D>("sprite//target");
            this.Game = game;
        }

        public override void Update(GameTime gameTime)
        {
            var mousePosition = Mouse.GetState().Position;
            if (mousePosition != this.pxCurrentPos)
            {
                this.pxCurrentPos = mousePosition;
                var tempTargetCell = BlackBoard.CurrentCamera.GetCellAtPosition(this.pxCurrentPos);
                if (this.CurrentCellTargeted != tempTargetCell)
                {
                    this.CurrentCellTargeted = tempTargetCell;
                    this.showTargetSprite = BlackBoard.CurrentCamera.IsCellOnCamera(this.CurrentCellTargeted);
                    if (this.showTargetSprite)
                    {
                        this.pxTargetSpriteOrigin = BlackBoard.CurrentCamera.GetPixelPositionOriginOfCell(this.CurrentCellTargeted);
                    }

                    this.Game.IsMouseVisible = !this.showTargetSprite;
                    BlackBoard.CurrentMap.CurrentTargetedCell = this.CurrentCellTargeted;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.showTargetSprite)
            {
                BlackBoard.CurrentSpriteBatch.Draw(this.targetTexture, this.pxTargetSpriteOrigin, Color.White);
            }

            base.Draw(gameTime);
        }
    }
}
