using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Crawler.Utils
{
    public static class Utilitaires
    {

        public static List<Vector2> RectangleDelimitationCells(Rectangle r)
        {
            var result = new List<Vector2>();
            var current = new Vector2(r.X, r.Y);
            for (int x = 0; x < r.Width; x++)
            {
                current.X++;
                result.Add(current);
            }

            for (int y = 0; y < r.Height; y++)
            {
                current.Y++;
                result.Add(current);
            }

            for (int x = 0; x < r.Width; x++)
            {
                current.X--;
                result.Add(current);
            }

            for (int y = 0; y < r.Height; y++)
            {
                current.Y--;
                result.Add(current);
            }
            return result;
        }
    }
}
