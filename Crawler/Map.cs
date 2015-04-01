using Crawler.Utils;

namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Crawler.Cells;
    using Crawler.Items;
    using Crawler.Living;
    using Crawler.Scheduling;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Map : DrawableGameComponent
    {
        public ListGameAware<Cell> board;

        private ListGameAware<Item> itemsOnBoard;

        private ListGameAware<LivingBeing> livingOnMap;
        private new GameEngine Game;


        private List<LivingBeing> beingToPlay;
        private SpriteBatch sb;
        private int timer = 0;

       
        public Map(GameEngine game, SpriteBatch sb)
            : base(game)
        {

            this.board = new ListGameAware<Cell>(game);
            
            this.Game = game;
            this.sb = sb;
            this.itemsOnBoard = new ListGameAware<Item>(game);
            this.livingOnMap = new ListGameAware<LivingBeing>(game);
           
           
            
        }


        public void InitializeBoard(Camera cam)
        {
            var rnd = new Random();

            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var po = new Vector2(i, j);
                    Cell c;
                    if (i % 50 != 0)
                    {
                        if (rnd.Next(100) == 50)
                        {
                            c = new Wall(this.Game, po, cam, sb);
                        }
                        else
                        {
                            c = new Floor(this.Game, po, cam, sb);
                        }
                    }
                    else
                    {
                        c = new Wall(this.Game, po, cam, sb);
                    }
                    this.board.Add(c);

                }
            }
        }

        public void InitializeItems(Camera c)
        {

            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(5, 5), c, this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(10, 5), c, this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(7, 2), c, this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(4, 11), c, this.sb));
            this.itemsOnBoard.Add(new Potion(this.Game, new Vector2(4, 11), c, this.sb));
            this.itemsOnBoard.Add(new Rod(this.Game, new Vector2(5, 5), c, this.sb));
        }

        public void InitializeEnnemis(Camera c,Scheduler s)
        {
            var b = new Bat(this.Game, new Vector2(1, 1), c, this.sb);
            this.livingOnMap.Add(b);
            b.IsUserControlled = false;
            s.AddABeing(b);
        }

        public void InitializePlayer(Camera c, Scheduler s)
        {
            var human = new Human(this.Game, new Vector2(4, 4), c, this.sb);
            human.IsUserControlled = true;
            this.livingOnMap.Add(human);
            s.AddABeing(human);
        }


        internal void HandleVisibility(LivingBeing being)
        {
            var posLb = being.positionCell;
            var listCell = this.GetPathsToDistanceMax(posLb, being.statistics.FOV);
            var totalList = new List<MapDrawableComponent>();
            totalList.AddRange(this.board);
            totalList.AddRange(this.itemsOnBoard);
            totalList.AddRange(this.livingOnMap);

            this.HandleVisibilityOfList(being, listCell, totalList);

        }

        private void HandleVisibilityOfList<T>(LivingBeing being, List<List<Vector2>> listPathOfVisibility, List<T> listGameAware) where T : MapDrawableComponent
        {
            //reinit visibility
            foreach (var element in listGameAware)
            {
                if (element.SeenBy.Contains(being.uniqueIdentifier))
                {
                    element.SetColorToUse(Visibility.Visited);
                }
                else
                {
                    element.SetColorToUse(Visibility.Unvisited);
                }
            }

            //handle new visibility
            var currentPos = being.positionCell;
            var listAtPos = listGameAware.Where(x => x.positionCell == currentPos);
            foreach (var v in listAtPos)
            {
                v.SetColorToUse(Visibility.InView);
                if (!v.SeenBy.Contains(being.uniqueIdentifier))
                {
                    v.SeenBy.Add(being.uniqueIdentifier);
                }
            }
            foreach (var path in listPathOfVisibility)
            {
                currentPos = being.positionCell;
                for (int i = 0; i < path.Count; i++)
                {
                    currentPos += path[i];
                    listAtPos = listGameAware.Where(x => x.positionCell == currentPos);
                    var stop = false;
                    foreach (var v in listAtPos)
                    {
                        v.SetColorToUse(Visibility.InView);
                        if (!v.SeenBy.Contains(being.uniqueIdentifier))
                        {
                            v.SeenBy.Add(being.uniqueIdentifier);
                        }
                        stop |= v.BlockVisibility(being);
                    }
                    if (stop)
                        break;

                }
            }
        }

        public List<List<Vector2>> GetPathsToDistanceMax(Vector2 begin, int distance)
        {
            var retour = new List<List<Vector2>>();
            var pathCalculator = new BasicRayPathCalculator();
            var current = new Vector2(begin.X - distance, begin.Y - distance);
            do
            {
                retour.Add(pathCalculator.FindPath(begin, current));
                current.X++;

            }
            while (current.X != begin.X + distance);


            do
            {

                retour.Add(pathCalculator.FindPath(begin, current));
                current.Y++;

            }
            while (current.Y != begin.Y + distance);

            do
            {

                retour.Add(pathCalculator.FindPath(begin, current));
                current.X--;

            }
            while (current.X != begin.X - distance);

            do
            {

                retour.Add(pathCalculator.FindPath(begin, current));
                current.Y--;

            }
            while (current.Y != begin.Y - distance);

            retour.Add(pathCalculator.FindPath(begin, current));


            return retour;


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
        }

        public void ShowInventory(LivingBeing lb)
        {
            lb.DumpInventory();
        }

        public void DropFirstObject(LivingBeing lb)
        {
            var itemToDrop = lb.Inventory.FirstOrDefault();
            if (itemToDrop != null)
            {
                lb.Inventory.Remove(itemToDrop);
                itemToDrop.positionCell = lb.positionCell;
                this.itemsOnBoard.Add(itemToDrop);
            }
        }

        public bool TryMoveLivingBeing(LivingBeing lb, Vector2 position)
        {
            var retour = false;
            var targetCellObject = this.CellOnPosition(position);
            if (null != targetCellObject)
            {
                if (targetCellObject.IsWalkable(lb))
                {
                    this.Game.MoveBeing(lb, position);
                    retour = true;
                }
            }
            return retour;
        }


    }

}
