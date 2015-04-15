namespace Crawler.UI
{
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class BasicLogPrinter : DrawableGameComponent, ILogPrinter
    {
        private List<string> Log;

        public Vector2 PositionPixel { get; set; }

        public Vector2 SizePixel { get; set; }
        private SpriteFont defaultFont { get; set; }

        private SpriteBatch sb;

        public BasicLogPrinter(GameEngine game, SpriteBatch sb)
            : base(game)
        {
            this.sb = sb;
            
            this.Log = new List<string>();
            this.Log.Add("i'm a test");
            this.Log.Add("a mother f*cker test");
            this.Log.Add("yeah baby");
            this.Log.Add("prout");
            this.Log.Add("Salut !");
            this.defaultFont = game.Content.Load<SpriteFont>("defaultFont");
        }



        public void AddLine(string text)
        {
            this.Log.Add(text);
        }

        public void AddLine(string text, params object[] values)
        {
            this.AddLine(string.Format(text, values));
        }


        public override void Draw(GameTime gameTime)
        {
            var listToAdd = this.Log.Skip(this.Log.Count - 5);
            var currentpos = this.PositionPixel;
            var posToAdd = this.defaultFont.LineSpacing-2;
            foreach (var text in listToAdd)
            {
                this.sb.DrawString(this.defaultFont, text, currentpos, Color.White);
                currentpos.Y += posToAdd;
            }

            base.Draw(gameTime);
        }
    }
}
