using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;

namespace Crawler.Utils
{
    public class BasicRayPathCalculator : IPathCalculator
    {
        public List<Vector2> FindPath(Vector2 origin, Vector2 target)
        {
            var diffVector = target - origin;
            var path = new List<Vector2>();
            //que du positif
            if (diffVector.X > 0 && diffVector.Y > 0)
            {
                // Y est plus rapide que X : SSW
                if (Math.Abs(diffVector.Y) > Math.Abs(diffVector.X))
                {
                    var currentPos = origin;
                    var totalError = 0F;
                    // diff X < diff  Y 
                    var error = Math.Abs(diffVector.X/diffVector.Y);
                    var deltaToApplyY = -1;
                    var deltaToApplyX = -1;
                    if (diffVector.Y > 0)
                        deltaToApplyY = 1;    
                    if (diffVector.X > 0)
                        deltaToApplyX = 1;


                    while (currentPos != target)
                    {
                        // on est sur Y
                        int depX = 0;
                        if (totalError >= 0.5)
                        {
                            totalError--;
                            depX = deltaToApplyX;
                        }
                        var newDepl = new Vector2(depX, deltaToApplyY);
                        totalError += error;
                        currentPos += newDepl;
                        path.Add(newDepl);
                    }
                }

            }
            return path;


        }
    }
}