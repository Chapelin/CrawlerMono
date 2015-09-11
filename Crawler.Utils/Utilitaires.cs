using Crawler.Utils.PathCalculator;

namespace Crawler.Utils
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

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

        public static List<List<Vector2>> GetPathsToDistanceMax(Vector2 begin, int distance)
        {
            var retour = new List<List<Vector2>>();
            var pathCalculator = new BasicRayPathCalculator();
            var current = new Vector2(begin.X - distance, begin.Y - distance);
            do
            {
                retour.Add(pathCalculator.FindPath(begin, current));
                current.X++;
            }
            while (current.X != begin.X + distance);

            do
            {

                retour.Add(pathCalculator.FindPath(begin, current));
                current.Y++;

            }
            while (current.Y != begin.Y + distance);

            do
            {

                retour.Add(pathCalculator.FindPath(begin, current));
                current.X--;

            }
            while (current.X != begin.X - distance);

            do
            {

                retour.Add(pathCalculator.FindPath(begin, current));
                current.Y--;

            }
            while (current.Y != begin.Y - distance);

            retour.Add(pathCalculator.FindPath(begin, current));

            return retour;
        }
    }
}
