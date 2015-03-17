using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;

namespace Crawler
{
    public class Helpers
    {

    }

    public static class Vector2Extensions
    {
        public static void AddPoint(this Vector2 a, Point p)
        {
            a.X += p.X;
            a.Y += p.Y;
        }
    }
}
