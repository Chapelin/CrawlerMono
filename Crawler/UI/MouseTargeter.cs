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

        private Texture2D tex;

        public MouseTargeter(GameEngine game, Camera c, SpriteBatch sb)
            : base(game)
        {
            this.c = c;
            this.pxCurrentPos = Point.Zero;
            this.pxTargetPos = Vector2.Zero;
            this.sb = sb;
            this.tex = game.Content.Load<Texture2D>("sprites//target");
        }

        public override void Update(GameTime gameTime)
        {
            var pospx = Mouse.GetState().Position;
            if (pospx != pxCurrentPos)
            {
                this.pxCurrentPos = pospx;
                this.toShow = c.IsOnCamera(this.pxCurrentPos);
                if (toShow)
                {
                    this.pxTargetPos = c.GetPixelPositionOriginOfCell(c.GetCellPositon(this.pxCurrentPos));
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
