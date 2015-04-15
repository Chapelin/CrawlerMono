namespace Crawler.Engine
{
    using System;

    using Crawler.UI;

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
            this.Offset = Vector2.Zero;
            this.SizeOfView = SizeOfView;
            this.CameraOffset = cameraOffset;
            this.log = log;
        }

        public void Move(Vector2 v)
        {
            var targetOffset = this.Offset + v;
            this.Offset = targetOffset;

        }

        public bool IsOnCamera(Vector2 position)
        {
            return !(position.X < this.Offset.X || position.Y < this.Offset.Y || position.X > this.Offset.X + this.SizeOfView.X
                   || position.Y > this.Offset.Y + this.SizeOfView.Y);

        }

        public bool IsOnCamera(Point pxCurrentPos)
        {
            return this.IsOnCamera(new Vector2(pxCurrentPos.X, pxCurrentPos.Y));
        }

        public Vector2 GetPixelPositionOriginOfCell(Vector2 cellPosition)
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

        public Vector2 GetCellPositon(Vector2 pxPosition)
        {
            var vec =  pxPosition / GameEngine.SpriteSize - this.CameraOffset;
            vec += this.Offset;
            return new Vector2((float)Math.Floor(vec.X), (float)Math.Floor(vec.Y));
        }

        public Vector2 GetCellPositon(Point pxCurrentPos)
        {
            return this.GetCellPositon(new Vector2(pxCurrentPos.X, pxCurrentPos.Y));
        }
    }
}
