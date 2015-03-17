using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Map : DrawableGameComponent
    {
        private List<Cell> board;

        private Player player;

        private SpriteBatch sb; 

        public Map(Game game) : base(game)
        {
            this.sb = new SpriteBatch(game.GraphicsDevice);
            this.board = new List<Cell>();
        }


        public void InitializeBoard()
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var po = new Point(i, j);
                    var c = new Cell(this.Game, po, i%50 == 0);
                    this.board.Add(c);
                    this.Game.Components.Add(c);
                }
            }
        }

        public void InitializePlayer()
        {
            this.player = new Player(this.Game,new Point(3,3));
        }

      
    }
}
