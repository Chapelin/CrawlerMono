namespace Crawler.Engine
{
    using System;

    using Microsoft.Xna.Framework;

    public class Camera
    {
        // X/Y beginning
        public Vector2 Offset { get; set; }
        public Vector2 SizeOfView { get; set; }

        // offset in px in the window
        public Vector2 CameraOffset
        {
            get;
            set;
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

        }

        public bool IsCellOnCamera(Vector2 position)
        {
            return !(position.X < this.Offset.X || position.Y < this.Offset.Y || position.X > this.Offset.X + this.SizeOfView.X
                   || position.Y > this.Offset.Y + this.SizeOfView.Y);

        }

        public Vector2 GetPixelPositionOriginOfCell(Vector2 cellPosition)
        {
            var vec = -this.Offset;
            vec += cellPosition;
            return (vec * GameEngine.SpriteSize) + this.CameraOffset;
        }

        public void CenterOnCell(Vector2 position)
        {
            this.Offset = position - this.SizeOfView / 2;
            this.Offset = new Vector2((float)Math.Floor(this.Offset.X), (float)Math.Floor(this.Offset.Y));
        }

        public Vector2 GetCellAtPosition(Vector2 pxPosition)
        {
            var vec = (pxPosition - this.CameraOffset) / GameEngine.SpriteSize;
            vec += this.Offset;
            return new Vector2((float)Math.Floor(vec.X), (float)Math.Floor(vec.Y));
        }

        public Vector2 GetCellAtPosition(Point pxCurrentPos)
        {
            return this.GetCellAtPosition(new Vector2(pxCurrentPos.X, pxCurrentPos.Y));
        }
    }
}
