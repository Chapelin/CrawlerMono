using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.UI
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

        private bool toShow;
        private Vector2 pxTargetPos;

        private SpriteBatch sb;

        private Vector2 CurrentCellTargeted;
        private Texture2D tex;

        public MouseTargeter(GameEngine game, Camera c, SpriteBatch sb)
            : base(game)
        {
            this.c = c;
            this.pxCurrentPos = Point.Zero;
            this.pxTargetPos = Vector2.Zero;
            this.sb = sb;
            this.CurrentCellTargeted = Vector2.Zero;
            this.tex = game.Content.Load<Texture2D>("sprite//target");
        }

        public override void Update(GameTime gameTime)
        {
            var pospx = Mouse.GetState().Position;
            if (pospx != pxCurrentPos)
            {
                this.pxCurrentPos = pospx;
                CurrentCellTargeted = c.GetCellAtPosition(this.pxCurrentPos);
                this.toShow = c.IsOnCamera(CurrentCellTargeted);
                if (toShow)
                {
                    this.pxTargetPos = c.GetPixelPositionOriginOfCell(CurrentCellTargeted);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (toShow)
            {
                sb.Draw(this.tex, this.pxTargetPos, Color.White);
            }


            base.Draw(gameTime);
        }
    }
}
