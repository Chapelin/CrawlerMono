namespace Crawler.MapGenerator
{
    using System.Collections.Generic;

    using Crawler.Engine;
    using Crawler.UI;

    using Microsoft.Xna.Framework;

    public class Dongeon
    {
        public List<Map> Levels;
        private GameEngine g;
        private ILogPrinter printer;
        private int _currentLevel;

        public int CurrentLevel
        {
            get { return this._currentLevel; }
            set
            {
                this._currentLevel = value;
                var diff = this._currentLevel - this.Levels.Count-1;
                while(diff < 0)
                {
                    this.AddALevel();
                    diff++;
                }
            }
        }

        public Dongeon(GameEngine e, ILogPrinter log)
        {
            this.Levels = new List<Map>();
            this.g = e;
            this.printer = log;
            this.GenerateLevels();
            this._currentLevel = 0;
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
            var map = new Map(this.g, this.printer, new Vector2(50, 50));
            bmg.GenerateBoard(map);
            this.Levels.Add(map);
        }

        public Map CurrentMap
        {
            get
            {
                return this.Levels[this._currentLevel];
            }
        }
    }
}
