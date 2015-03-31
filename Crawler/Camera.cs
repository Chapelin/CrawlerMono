using System;

namespace Crawler
{
    using Microsoft.Xna.Framework;

    public class Camera
    {
        // X/Y beginning
        public Vector2 Offset { get; set; }
        public Vector2 SizeOfView { get; set; }

        private GameEngine g;

        public Camera(GameEngine g)
        {
            this.g = g;
            this.Offset = Vector2.Zero;
            this.SizeOfView = new Vector2(g.graphics.PreferredBackBufferWidth / GameEngine.SpriteSize, g.graphics.PreferredBackBufferHeight / GameEngine.SpriteSize);
        }

        public void Move(Vector2 v)
        {
            var targetOffset = this.Offset + v;
            this.Offset = targetOffset;
            this.Offset = targetOffset;

        }

        public bool IsOnCamera(Vector2 position)
        {
            return !(position.X < Offset.X || position.Y < Offset.Y || position.X > Offset.X + this.SizeOfView.X
                   || position.Y > Offset.Y + this.SizeOfView.Y);

        }

        public Vector2 GetPixelPosition(Vector2 cellPosition)
        {
            var vec = -this.Offset;
            vec += cellPosition;
            return vec * GameEngine.SpriteSize;

        }

        public void CenterOn(Vector2 position)
        {
            this.Offset = position - this.SizeOfView / 2;
            this.Offset = new Vector2((float)Math.Floor(this.Offset.X),(float)Math.Floor(this.Offset.Y));
        }

    }
}
