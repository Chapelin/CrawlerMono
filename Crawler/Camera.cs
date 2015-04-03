using System;

namespace Crawler
{
    using Microsoft.Xna.Framework;

    public class Camera
    {
        // X/Y beginning
        public Vector2 Offset { get; set; }
        public Vector2 SizeOfView { get; set; }

        // offset in px in the window
        public Vector2 CameraOffset
        {
            get; set;
            
        }

        public Camera(GameEngine g)
            : this(new Vector2(g.graphics.PreferredBackBufferWidth / GameEngine.SpriteSize, g.graphics.PreferredBackBufferHeight / GameEngine.SpriteSize), Vector2.Zero)
        {

        }

        public Camera(Vector2 SizeOfView, Vector2 cameraOffset)
        {
            this.Offset = Vector2.Zero;
            this.SizeOfView = SizeOfView;
            this.CameraOffset = cameraOffset;
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
            return vec * GameEngine.SpriteSize + this.CameraOffset;

        }

        public void CenterOn(Vector2 position)
        {
            this.Offset = position - this.SizeOfView / 2;
            this.Offset = new Vector2((float)Math.Floor(this.Offset.X), (float)Math.Floor(this.Offset.Y));
        }

    }
}
