using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Crawler.Utils
{
    public class SimplePathCalculator
    {
        public List<Vector2> FindPath(Vector2 origin, Vector2 target)
        {
            var result = new List<Vector2>();
            if (origin == target)
                return result;

            var diffVector = target - origin;
            var currentpo = origin;
            Vector2 nex;
            if (diffVector.X != 0 && diffVector.Y != 0)
            {
                //diagonal first
                var vectorDiag = GetDifferentialVector(diffVector);
                while (!(currentpo.X == target.X || currentpo.Y == target.Y))
                {
                    nex = currentpo + vectorDiag;
                    result.Add(vectorDiag);
                    currentpo = nex;
                }
            }

            // now diag is done, we fill the gap
            diffVector = target - currentpo;
            var gadDir = GetDifferentialVector(diffVector);

            while (!(currentpo.X == target.X && currentpo.Y == target.Y))
            {
                nex = currentpo + gadDir;
                result.Add(gadDir);
                currentpo = nex;

            }
            return result;
        }

        private Vector2 GetDifferentialVector(Vector2 diffVector)
        {
            var xDirection = diffVector.X == 0 ? 0 : diffVector.X / Math.Abs(diffVector.X);
            var yDirection = diffVector.Y == 0 ? 0 : diffVector.Y / Math.Abs(diffVector.Y);
            var gadDir = new Vector2(xDirection, yDirection);
            return gadDir;
        }
    }
}
