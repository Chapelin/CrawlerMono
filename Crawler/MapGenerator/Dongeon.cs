using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler.MapGenerator
{
    public class Dongeon
    {
        public List<Map> Levels;
        private GameEngine g;
        private Camera c;
        private SpriteBatch sb;
        private ILogPrinter printer;
        private int _currentLevel;

        public int CurrentLevel
        {
            get { return _currentLevel; }
            set
            {
                _currentLevel = value;
                var diff = _currentLevel - this.Levels.Count;
                while(diff > 0)
                {
                    this.AddALevel();
                    diff--;
                }
            }
        }

        public Dongeon(GameEngine e,Camera c, SpriteBatch sb, ILogPrinter log)
        {
            Levels = new List<Map>();
            this.c = c;
            g = e;
            this.sb = sb;
            printer = log;
            GenerateLevels();
            _currentLevel = 0;
        }

        private void GenerateLevels()
        {
            AddALevel();
            AddALevel();
            AddALevel();
        }

        public void AddALevel()
        {
            var bmg = new BasicMapGenerator(8, new Vector2(30, 30), new Vector2(3, 3), new Vector2(5, 5));
            var map = new Map(g, sb, printer, new Vector2(50, 50));
            bmg.GenerateBoard(map, c);
            Levels.Add(map);
        }

        public Map CurrentMap
        {
            get
            {
                return Levels[_currentLevel];
            }
        }

       
    }
}
