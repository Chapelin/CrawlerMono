namespace Crawler
{
    using System;

    using Microsoft.Xna.Framework;

    public class Camera
    {
        private ILogPrinter log;
        // X/Y beginning
        public Vector2 Offset { get; set; }
        public Vector2 SizeOfView { get; set; }

        // offset in px in the window
        public Vector2 CameraOffset
        {
            get; set;
            
        }

        public Camera(Vector2 SizeOfView, Vector2 cameraOffset, ILogPrinter log)
        {
            Offset = Vector2.Zero;
            this.SizeOfView = SizeOfView;
            CameraOffset = cameraOffset;
            this.log = log;
        }

        public void Move(Vector2 v)
        {
            var targetOffset = Offset + v;
            Offset = targetOffset;

        }

        public bool IsOnCamera(Vector2 position)
        {
            return !(position.X < Offset.X || position.Y < Offset.Y || position.X > Offset.X + SizeOfView.X
                   || position.Y > Offset.Y + SizeOfView.Y);

        }

        public Vector2 GetPixelPosition(Vector2 cellPosition)
        {
            var vec = -Offset;
            vec += cellPosition;
            return vec * GameEngine.SpriteSize + CameraOffset;

        }

        public void CenterOn(Vector2 position)
        {
            Offset = position - SizeOfView / 2;
            Offset = new Vector2((float)Math.Floor(Offset.X), (float)Math.Floor(Offset.Y));
        }

    }
}
