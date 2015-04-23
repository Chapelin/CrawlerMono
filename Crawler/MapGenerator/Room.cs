namespace Crawler.MapGenerator
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

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
