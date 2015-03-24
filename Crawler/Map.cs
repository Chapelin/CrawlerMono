﻿using System.Collections.Generic;
using System.Linq;
using Crawler.Cells;
using Crawler.Living;
using Microsoft.Xna.Framework;

namespace Crawler
{
    using Crawler.Items;

    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Map : DrawableGameComponent
    {
        private List<Cell> board;

        private List<Item> itemsOnBoard;

        private Game1 Game;
        private Player player;


        private SpriteBatch sb;
        private Camera c;
        private int timer = 0;

        public Map(Game1 game, SpriteBatch sb)
            : base(game)
        {
            this.board = new List<Cell>();
            this.c = new Camera(game);
            this.Game = game;
            this.sb = sb;
            this.itemsOnBoard = new List<Item>();
        }


        public void InitializeBoard()
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var po = new Vector2(i, j);
                    Cell c;
                    if (i % 50 != 0)
                    {
                        c = new Floor(this.Game, po, this.c, sb);
                    }
                    else
                    {
                        c = new Wall(this.Game, po, this.c, sb);
                    }
                    this.board.Add(c);
                    this.Game.Components.Add(c);
                }
            }
        }

        public void InitializeItems()
        {

            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(5, 5), this.c, "sprite\\potion", this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(10, 5), this.c, "sprite\\potion", this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(7, 2), this.c, "sprite\\potion", this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(4, 11), this.c, "sprite\\potion", this.sb));
            this.itemsOnBoard.ForEach(x => this.Game.Components.Add(x));
        }

        public void InitializeEnnemis()
        {
            var b = new Bat(this.Game, new Vector2(1, 1), this.c, this.sb);
            this.Game.Components.Add(b);
        }

        public void InitializePlayer()
        {
            this.player = new Player(this.Game, new Vector2(3, 3), this.c, this.sb);
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

                if (k.GetPressedKeys().Contains(Keys.Space))
                {
                    this.c.CenterOn(this.player.positionCell);
                }
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
                if (targetCellObject.IsWalkable(this.player))
                {
                    MovePlayer(this.player, targetCell);
                    timer = 30;
                }
            }
        }

        public void MovePlayer(Player p, Vector2 targetPosition)
        {

            var currentCell = this.board.First(x => x.positionCell == p.positionCell);
            currentCell.OnExit(p);
            this.c.Move(targetPosition - p.positionCell);
            p.positionCell = targetPosition;
            var targetCell = this.board.First(x => x.positionCell == targetPosition);
            targetCell.OnEnter(p);

        }

        public IEnumerable<Item> ItemOnCell(Vector2 targetPosition)
        {
            return this.itemsOnBoard.Where(x => x.positionCell == targetPosition);
        }

    }

}
