﻿namespace Crawler
{
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Cells;
    using Crawler.Items;
    using Crawler.Living;
    using Crawler.Scheduling;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Map : DrawableGameComponent
    {
        private ListGameAware<Cell> board;

        private ListGameAware<Item> itemsOnBoard;

        private ListGameAware<LivingBeing> livingOnMap;
        private new Game1 Game;

        private Scheduler scheduler;

        private List<LivingBeing> beingToPlay;
        private SpriteBatch sb;
        private Camera c;
        private int timer = 0;

        private KeyBoardInputHandler hd;
        public Map(Game1 game, SpriteBatch sb)
            : base(game)
        {

            this.board = new ListGameAware<Cell>(game);
            this.c = new Camera(game);
            this.Game = game;
            this.sb = sb;
            this.itemsOnBoard = new ListGameAware<Item>(game);
            this.livingOnMap = new ListGameAware<LivingBeing>(game);
            this.scheduler = new Scheduler();
            this.beingToPlay = new List<LivingBeing>();
            this.hd = new KeyBoardInputHandler(this.c, this);
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

                }
            }
        }

        public void InitializeItems()
        {

            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(5, 5), this.c, this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(10, 5), this.c, this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(7, 2), this.c, this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(4, 11), this.c, this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(4, 11), this.c, this.sb));
            this.itemsOnBoard.Add(new Rod(this.Game, new Vector2(5, 5), this.c, this.sb));
        }

        public void InitializeEnnemis()
        {
            var b = new Bat(this.Game, new Vector2(1, 1), this.c, this.sb);
            this.livingOnMap.Add(b);
            this.scheduler.AddABeing(b);
        }

        public void InitializePlayer()
        {
            var human = new Human(this.Game, new Vector2(4, 4), this.c, this.sb);
            human.IsUserControlled = true;
            this.livingOnMap.Add(human);
            this.scheduler.AddABeing(human);
        }

        public override void Update(GameTime gameTime)
        {
            // if list empty
            if (!beingToPlay.Any())
            {
                beingToPlay = this.scheduler.NextPlaying().ToList();
            }

            //for each being to play
            var automatedBeing = beingToPlay.Where(x => !x.IsUserControlled);
            // we delete them from the list to play

            foreach (var livingBeing in automatedBeing)
            {
                // and we autoplay theù
                livingBeing.AutoPlay();
            }
            beingToPlay.RemoveAll(x => !x.IsUserControlled);

            // we handle only one user controller for now
            // the Player
            if (beingToPlay.Any(x => x.IsUserControlled))
            {
                var being = beingToPlay.First();
                this.hd.HandleInput(being);
            }

            base.Update(gameTime);
        }


        public void MoveBeing(LivingBeing p, Vector2 targetPosition)
        {

            var currentCell = this.board.First(x => x.positionCell == p.positionCell);
            currentCell.OnExit(p);
            this.c.Move(targetPosition - p.positionCell);
            p.positionCell = targetPosition;
            var targetCell = this.board.First(x => x.positionCell == targetPosition);
            targetCell.OnEnter(p);
            // we have played, so we remove it
            this.beingToPlay.RemoveAt(0);

        }

        public IEnumerable<Item> ItemOnPosition(Vector2 targetPosition)
        {
            return this.itemsOnBoard.Where(x => x.positionCell == targetPosition);
        }

        public Cell CellOnPosition(Vector2 targetposition)
        {
            return this.board.FirstOrDefault(x => x.positionCell == targetposition);
        }

        public void RemoveItems(List<Item> it)
        {
            this.itemsOnBoard.RemoveList(it);
        }

        public void Pickup(LivingBeing lb)
        {
            var listObject = this.ItemOnPosition(lb.positionCell).ToList();
            lb.Inventory.AddRange(listObject);
            this.RemoveItems(listObject);
            lb.DumpInventory();
        }


    }

}
