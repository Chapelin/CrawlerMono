using Crawler.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class DrawingComponant : DrawableGameComponent
    {
        public Texture2D Sprite { get; set; }

        public GameEngine Game { get; set; }

        public float Z { get; set; }

        public Color ColorToUse { get; set; }

        public Vector2 position;

        public DrawingComponant(GameEngine g, string SpriteName, float z) : base(g)
        {
            this.Game = g;
            this.Sprite = this.Game.Content.Load<Texture2D>(SpriteName);
            this.Z = z;
            this.ColorToUse = Color.White;
        }

        public override void Draw(GameTime gameTime)
        {
            if (BlackBoard.CurrentCamera.IsCellOnCamera(position))
            {
                BlackBoard.CurrentSpriteBatch.Draw(this.Sprite, BlackBoard.CurrentCamera.GetPixelPositionOriginOfCell(position), layerDepth: this.Z, color: this.ColorToUse);
            }
        }

    }
}
