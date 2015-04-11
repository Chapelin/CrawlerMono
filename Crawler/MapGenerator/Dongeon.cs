using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    using Crawler.Utils.MapGenerator;

    using Microsoft.Xna.Framework;

    public class Dongeon
    {
        public List<Map> Levels;
        private GameEngine g;
        private Camera c;
        private SpriteBatch sb;
        private ILogPrinter printer;
        public int currentLevel;
        public Dongeon(GameEngine e,Camera c, SpriteBatch sb, ILogPrinter log)
        {
            Levels = new List<Map>();
            this.c = c;
            this.g = e;
            this.sb = sb;
            this.printer = log;
            this.GenerateLevels();
            this.currentLevel = 0;
        }

        private void GenerateLevels()
        {
            this.AddALevel();
            this.AddALevel();
            this.AddALevel();
        }

        public void AddALevel()
        {
            var bmg = new BasicMapGenerator(8, new Vector2(30, 30), new Vector2(3, 3), new Vector2(5, 5));
            var map = new Map(this.g, this.sb, this.printer, new Vector2(50, 50));
            bmg.GenerateBoard(map, this.c);
            Levels.Add(map);
        }

        public Map CurrentMap
        {
            get { return this.Levels[this.currentLevel]; }
        }


    }
}
