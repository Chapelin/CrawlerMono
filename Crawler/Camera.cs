﻿namespace Crawler
{
    using Microsoft.Xna.Framework;

    public class Camera
    {
        // X/Y beginning
        public Vector2 Offset { get; set; }
        public Vector2 Size { get; set; }

        private Game1 g;

        public Camera(Game1 g)
        {
            this.g = g;
            this.Offset = Vector2.Zero;
            this.Size = new Vector2(g.graphics.PreferredBackBufferWidth / Game1.SpriteSize, g.graphics.PreferredBackBufferHeight / Game1.SpriteSize);
        }

        public void Move(Vector2 v)
        {
            var targetOffset = this.Offset + v;
            this.Offset = targetOffset;
            this.Offset = targetOffset;

        }

        public bool IsOnCamera(Vector2 position)
        {
            return !(position.X < Offset.X || position.Y < Offset.Y || position.X > Offset.X + Size.X
                   || position.Y > Offset.Y + Size.Y);

        }

        public Vector2 GetPixelPosition(Vector2 cellPosition)
        {
            var vec = -this.Offset;
            vec += cellPosition;
            return vec * Game1.SpriteSize;

        }

        public void CenterOn(Vector2 position)
        {
            this.Offset = position - this.Size / 2;
        }

    }
}
