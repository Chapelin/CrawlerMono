using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
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
            
            Log = new List<string>();
            Log.Add("i'm a test");
            Log.Add("a mother f*cker test");
            Log.Add("yeah baby");
            Log.Add("prout");
            Log.Add("Salut !");
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
                sb.DrawString(defaultFont, text, currentpos, Color.White);
                currentpos.Y += posToAdd;
            }

            base.Draw(gameTime);
        }
    }
}
