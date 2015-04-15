using Crawler.Utils;

namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Cells;
    using Items;
    using Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Map : DrawableGameComponent
    {
        public ListGameAware<Cell> board;

        public ListGameAware<Item> itemsOnBoard;

        public ListGameAware<LivingBeing> livingOnMap;
        public  new GameEngine Game;

        internal SpriteBatch sb;
        private ILogPrinter log;

        public Vector2 SizeOfMap;

        public Map(GameEngine game, SpriteBatch sb, ILogPrinter lp, Vector2 size = default(Vector2))
            : base(game)
        {
            if(size == default(Vector2))
                size = new Vector2(50,50);
            Game = game;
            log = lp;
            this.sb = sb;
            itemsOnBoard = new ListGameAware<Item>(game);
            livingOnMap = new ListGameAware<LivingBeing>(game);
            board = new ListGameAware<Cell>(game);
            SizeOfMap = size;
        }


      

        internal void HandleVisibility(LivingBeing being)
        {
            var posLb = being.positionCell;
            var listCell = Utilitaires.GetPathsToDistanceMax(posLb, being.statistics.TotalStatistics.FOV);
            var totalList = new List<MapDrawableComponent>();
            totalList.AddRange(board);
            totalList.AddRange(itemsOnBoard);
            totalList.AddRange(livingOnMap);

            HandleVisibilityOfList(being, listCell, totalList);

        }

        private void HandleVisibilityOfList<T>(LivingBeing being, List<List<Vector2>> listPathOfVisibility, List<T> listGameAware) where T : MapDrawableComponent
        {
            //reinit visibility
            Parallel.ForEach(
                listGameAware,
                element =>
                {
                    if (element.SeenBy.Contains(being.uniqueIdentifier))
                    {
                        element.SetColorToUse(Visibility.Visited);
                    }
                    else
                    {
                        element.SetColorToUse(Visibility.Unvisited);
                    }
                });

            //handle new visibility
            var currentPosition = being.positionCell;
            var listAtPos = listGameAware.Where(x => x.positionCell == currentPosition);
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
                var currentPos = being.positionCell;
                foreach (Vector2 t in path)
                {
                    currentPos += t;
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

     



        public IEnumerable<Item> ItemOnPosition(Vector2 targetPosition)
        {
            return itemsOnBoard.Where(x => x.positionCell == targetPosition);
        }

        public Cell CellOnPosition(Vector2 targetposition)
        {
            return board.FirstOrDefault(x => x.positionCell == targetposition);
        }

        public void RemoveLivingBeing(LivingBeing lb)
        {
            livingOnMap.Remove(lb);
        }

        public void AddLivingBeing(LivingBeing lb, Vector2 pos)
        {
            lb.positionCell = pos;
            livingOnMap.Add(lb);

        }

        public void RemoveItems(List<Item> it)
        {
            itemsOnBoard.RemoveList(it);
        }

        public void Pickup(LivingBeing lb)
        {
            var listObject = ItemOnPosition(lb.positionCell).ToList();
            lb.Inventory.AddRange(listObject);
            RemoveItems(listObject);
        }

        public void ShowInventory(LivingBeing lb)
        {
            lb.DumpInventory();
        }

        public void DropFirstObject(LivingBeing lb)
        {
            var itemToDrop = lb.Inventory.FirstOrDefault(x=> !x.IsEquipped);
            if (itemToDrop != null)
            {
                lb.Inventory.Remove(itemToDrop);
                itemToDrop.positionCell = lb.positionCell;
                itemsOnBoard.Add(itemToDrop);
            }
        }

        public bool TryMoveLivingBeing(LivingBeing lb, Vector2 position)
        {
            var retour = false;
            var targetCellObject = CellOnPosition(position);
            if (null != targetCellObject)
            {
                if (targetCellObject.IsWalkable(lb))
                {
                    Game.MoveBeing(lb, position);
                    retour = true;
                }
            }
            return retour;
        }

        public void SetAsActive(bool toActive)
        {
            board.IsActive = toActive;
            livingOnMap.IsActive = toActive;
            itemsOnBoard.IsActive = toActive;
        }
    }

}
