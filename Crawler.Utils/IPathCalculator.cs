using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Crawler.Utils
{
    public interface IPathCalculator
    {
        List<Vector2> FindPath(Vector2 origin, Vector2 target);
    }
}