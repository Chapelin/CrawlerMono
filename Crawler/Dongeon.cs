using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    using Crawler.Utils.MapGenerator;

    using Microsoft.Xna.Framework;

    public class Dongeon
    {
        public List<Map> Levels;

        private Camera c;

        public Dongeon(Camera c)
        {
            Levels = new List<Map>();
            this.c = c;
        }

        public void AddALevel(Map m)
        {
            var bmg = new BasicMapGenerator(8, new Vector2(30, 30), new Vector2(3, 3), new Vector2(5, 5));
            bmg.GenerateBoard(m, this.c);
            Levels.Add(m);
        }

    }
}
