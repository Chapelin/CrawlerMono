using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Crawler.MapGenerator
{
    using Engine;
    using UI;

    public class Dongeon
    {
        public List<Map> Levels;
        private GameEngine g;
        private ILogPrinter printer;
        private int _currentLevel;

        public int CurrentLevel
        {
            get { return _currentLevel; }
            set
            {
                _currentLevel = value;
                var diff = _currentLevel - Levels.Count;
                while(diff > 0)
                {
                    AddALevel();
                    diff--;
                }
            }
        }

        public Dongeon(GameEngine e, ILogPrinter log)
        {
            Levels = new List<Map>();
            g = e;
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
            var map = new Map(g, printer, new Vector2(50, 50));
            bmg.GenerateBoard(map);
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
