using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crawler.Cells;
using Crawler.Engine;
using Crawler.Living;
using Crawler.Utils;
using Microsoft.Xna.Framework;

namespace Crawler.Helpers
{
    public static class VisibilityHandler
    {
        private static void ProcessVisibilityWithFOV(LivingBeing being, List<List<Vector2>> listPathOfVisibility, List<MapDrawableComponent> listGameAware)
        {
            IEnumerable<MapDrawableComponent> listAtPos;
            foreach (var path in listPathOfVisibility)
            {
                var currentPos = being.positionCell;
                foreach (Vector2 t in path)
                {
                    currentPos += t;
                    listAtPos = listGameAware.Where(x => x.positionCell == currentPos);
                    var stop = false;
                    foreach (var v in listAtPos)
                    {
                        v.SetColorToUse(Visibility.InView);
                        if (!v.SeenBy.Contains(being.uniqueIdentifier))
                        {
                            v.SeenBy.Add(being.uniqueIdentifier);
                        }
                        stop |= v.BlockVisibility(being);
                    }
                    if (stop)
                        break;
                }
            }
        }

        private static void ReitinializeVisibility(LivingBeing being, List<MapDrawableComponent> listGameAware)
        {
            Parallel.ForEach(
                listGameAware,
                element =>
                {
                    if (element.SeenBy.Contains(being.uniqueIdentifier))
                    {
                        element.SetColorToUse(Visibility.Visited);
                    }
                    else
                    {
                        element.SetColorToUse(Visibility.Unvisited);
                    }
                });
        }

        public  static void HandleVisibilityOfList(LivingBeing being, List<MapDrawableComponent> listGameAware)
        {
            var currentPosition = being.positionCell;

            //reinit visibility
           ReitinializeVisibility(being, listGameAware);

            var listPathOfVisibility = Utilitaires.GetPathsToDistanceMax(currentPosition, being.statistics.FOV);
            //handle new visibility
            var listAtPos = listGameAware.Where(x => x.positionCell == currentPosition);
            foreach (var v in listAtPos)
            {
                v.SetColorToUse(Visibility.InView);
                if (!v.SeenBy.Contains(being.uniqueIdentifier))
                {
                    v.SeenBy.Add(being.uniqueIdentifier);
                }
            }
            ProcessVisibilityWithFOV(being, listPathOfVisibility, listGameAware);
        }
    }
}
