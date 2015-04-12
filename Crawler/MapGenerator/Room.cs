using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Crawler.MapGenerator
{
    public class Room
    {
        public Rectangle Setting;
        public List<Exit> IOs;

        public Room()
        {
            IOs = new List<Exit>();
        }
    }
}
