using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The drawable from tile set.
    /// </summary>
    public class DrawableFromTileSet : DrawableGameComponent
    {
        public Texture2D tileSet;

        public Rectangle cursor;

        public int numberOfTileX;

        public int numberOfTileY;

        public Point tileSize;

        public Rectangle TargetRectangle;

        public SpriteBatch sb;
        public DrawableFromTileSet(Game g, string tileset, int nx, int ny, int tx, int ty)
            : base(g)
        {
            this.tileSet = g.Content.Load<Texture2D>(tileset);
            this.numberOfTileX = nx;
            this.numberOfTileY = ny;
            this.tileSize = new Point(tx, ty);
            this.cursor = new Rectangle(0, 0, this.tileSize.X, this.tileSize.Y);
            this.TargetRectangle = new Rectangle(0, 0, this.tileSize.X, this.tileSize.Y);
            this.sb = new SpriteBatch(this.Game.GraphicsDevice);
        }

        public override void Initialize()
        {
           
            base.Initialize();
        }

        public void SetCursorTo(int index)
        {
            var x = (index % numberOfTileX) * tileSize.X;
            var y = (index / numberOfTileY) * tileSize.Y;
            this.cursor.X = x;
            this.cursor.Y = y;
        }

        public void MoveTo(int x, int y)
        {
            this.TargetRectangle.X = x;
            this.TargetRectangle.Y = y;
        }

        public override void Draw(GameTime gameTime)
        {
            this.sb.Begin();
            this.sb.Draw(tileSet,TargetRectangle,cursor,Color.White);
            this.sb.End();
            base.Draw(gameTime);
        }
    }
}
