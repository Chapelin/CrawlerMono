﻿using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;

namespace Crawler
{
    using Microsoft.Xna.Framework.Input;

    public class Map : DrawableGameComponent
    {
        private List<Cell> board;

        private Player player;

        private Camera c;
        private int timer = 0;

        public Map(Game1 game)
            : base(game)
        {
            this.board = new List<Cell>();
            this.c = new Camera(game);
        }


        public void InitializeBoard()
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var po = new Vector2(i, j);
                    var c = new Cell(this.Game, po, i % 50 != 0,this.c);
                    this.board.Add(c);
                    this.Game.Components.Add(c);
                }
            }
        }

        public void InitializePlayer()
        {
            this.player = new Player(this.Game, new Vector2(3, 3),this.c);
            this.Game.Components.Add(this.player);
        }

        public override void Update(GameTime gameTime)
        {
            var k = Keyboard.GetState();
            if (timer > 0)
            {
                timer--;
            }
            if (k.GetPressedKeys().Any())
            {
                if (timer == 0)
                    this.HandleKeyboardPlayerMovement(k);
            }

            base.Update(gameTime);
        }

        private void HandleKeyboardPlayerMovement(KeyboardState k)
        {
            var targetCell = this.player.positionCell;
            if (k.IsKeyDown(Keys.NumPad2))
            {
                targetCell.Y++;
            }
            if (k.IsKeyDown(Keys.NumPad4))
            {
                targetCell.X--;
            }
            if (k.IsKeyDown(Keys.NumPad8))
            {
                targetCell.Y--;
            }
            if (k.IsKeyDown(Keys.NumPad6))
            {
                targetCell.X++;
            }
            if (k.IsKeyDown(Keys.NumPad9))
            {
                targetCell += new Vector2(1, -1);
            }
            if (k.IsKeyDown(Keys.NumPad7))
            {
                targetCell += new Vector2(-1, -1);
            }
            if (k.IsKeyDown(Keys.NumPad1))
            {
                targetCell += new Vector2(-1, 1);
            }
            if (k.IsKeyDown(Keys.NumPad3))
            {
                targetCell += new Vector2(1, 1);
            }

            var targetCellObject = this.board.FirstOrDefault(x => x.positionCell == targetCell);
            if (null != targetCellObject)
            {
                if (targetCellObject.IsWalkable)
                {
                    this.player.positionCell = targetCell;
                    timer = 30;
                }
            }
        }
    }
}
