using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Crawler.Utils.PathCalculator
{
    public class BasicRayPathCalculator : IPathCalculator
    {
        public List<Vector2> FindPath(Vector2 origin, Vector2 target)
        {
            var diffVector = target - origin;
            var path = new List<Vector2>();

            var isYGreater = Math.Abs(diffVector.Y) > Math.Abs(diffVector.X);
            var currentPos = origin;
            var totalError = 0F;
            var deltaToApplyY = Math.Sign(diffVector.Y);
            var deltaToApplyX = Math.Sign(diffVector.X);

            var error = isYGreater ? Math.Abs(diffVector.X / diffVector.Y) : Math.Abs(diffVector.Y / diffVector.X);

            while (currentPos != target)
            {
                int dep = 0;
                totalError += error;
                if (totalError >= 0.5)
                {
                    totalError--;
                    dep = isYGreater ? deltaToApplyX : deltaToApplyY;
                }
                var newDepl = isYGreater ? new Vector2(dep, deltaToApplyY) : new Vector2(deltaToApplyX, dep);
                currentPos += newDepl;
                path.Add(newDepl);
            }

            return path;


        }
    }
}