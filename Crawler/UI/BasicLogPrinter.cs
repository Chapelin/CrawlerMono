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
            defaultFont = game.Content.Load<SpriteFont>("defaultFont");
        }



        public void AddLine(string text)
        {
            Log.Add(text);
        }

        public void AddLine(string text, params object[] values)
        {
            AddLine(string.Format(text, values));
        }


        public override void Draw(GameTime gameTime)
        {
            var listToAdd = Log.Skip(Log.Count - 5);
            var currentpos = PositionPixel;
            var posToAdd = defaultFont.LineSpacing-2;
            foreach (var text in listToAdd)
            {
                sb.DrawString(defaultFont, text, currentpos, Color.White);
                currentpos.Y += posToAdd;
            }

            base.Draw(gameTime);
        }
    }
}
