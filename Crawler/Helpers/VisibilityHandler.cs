using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Crawler.Cells;
using Crawler.Engine;
using Crawler.Utils;

using Microsoft.Xna.Framework;

namespace Crawler.Helpers
{
    using Crawler.GameObjects.Living;

    public static class VisibilityHandler
    {
        private static void ProcessVisibilityWithFOV(LivingBeing being, List<List<Vector2>> listPathOfVisibility, List<MapComponent> listGameAware)
        {
            IEnumerable<MapComponent> listAtPos;
            foreach (var path in listPathOfVisibility)
            {
                var currentPos = being.PositionCell;
                foreach (Vector2 t in path)
                {
                    currentPos += t;
                    listAtPos = listGameAware.Where(x => x.PositionCell == currentPos);
                    var stop = false;
                    foreach (var v in listAtPos)
                    {
                        v.SetColorToUse(Visibility.InView);
                        if (!v.SeenBy.Contains(being.UniqueIdentifier))
                        {
                            v.SeenBy.Add(being.UniqueIdentifier);
                        }

                        stop |= v.BlockVisibility(being);
                    }

                    if (stop)
                        break;
                }
            }
        }

        private static void ReitinializeVisibility(LivingBeing being, List<MapComponent> listGameAware)
        {
            Parallel.ForEach(
                listGameAware, 
                element =>
                {
                    if (element.SeenBy.Contains(being.UniqueIdentifier))
                    {
                        element.SetColorToUse(Visibility.Visited);
                    }
                    else
                    {
                        element.SetColorToUse(Visibility.Unvisited);
                    }
                });
        }

        public  static void HandleVisibilityOfList(LivingBeing being, List<MapComponent> listGameAware)
        {
            var currentPosition = being.PositionCell;

            // reinit visibility
            ReitinializeVisibility(being, listGameAware);

            var listPathOfVisibility = Utilitaires.GetPathsToDistanceMax(currentPosition, being.Statistics.FOV);

            // handle new visibility
            var listAtPos = listGameAware.Where(x => x.PositionCell == currentPosition);
            foreach (var v in listAtPos)
            {
                v.SetColorToUse(Visibility.InView);
                if (!v.SeenBy.Contains(being.UniqueIdentifier))
                {
                    v.SeenBy.Add(being.UniqueIdentifier);
                }
            }

            ProcessVisibilityWithFOV(being, listPathOfVisibility, listGameAware);
        }
    }
}
