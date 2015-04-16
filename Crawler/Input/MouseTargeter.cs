namespace Crawler.Input
{
    using Crawler.Engine;

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

        private Vector2 CurrentCellTargeted;
        private Texture2D targetTexture;

        public MouseTargeter(GameEngine game, Camera c, SpriteBatch sb)
            : base(game)
        {
            this.c = c;
            this.pxCurrentPos = Point.Zero;
            this.pxTargetSpriteOrigin = Vector2.Zero;
            this.sb = sb;
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
                this.CurrentCellTargeted = this.c.GetCellAtPosition(this.pxCurrentPos);
                this.showTargetSprite = this.c.IsCellOnCamera(this.CurrentCellTargeted);
                if (this.showTargetSprite)
                {
                    this.pxTargetSpriteOrigin = this.c.GetPixelPositionOriginOfCell(this.CurrentCellTargeted);
                }

                this.Game.IsMouseVisible = !this.showTargetSprite;
            }


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (this.showTargetSprite)
            {
                
                this.sb.Draw(this.targetTexture, this.pxTargetSpriteOrigin, Color.White);
            }



            base.Draw(gameTime);
        }
    }
}
