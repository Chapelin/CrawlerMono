namespace Crawler.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Crawler.Cells;
    using Crawler.DataStructures;
    using Crawler.Items;
    using Crawler.Living;
    using Crawler.UI;
    using Crawler.Utils;

    using Microsoft.Xna.Framework;

    public class Map : DrawableGameComponent
    {
        public ListGameAware<MapDrawableComponent> fullBoard;

        public new GameEngine Game;

        private ILogPrinter log;

        public Vector2 SizeOfMap;

        private Vector2 _currentTargetedCell;

        public Vector2 CurrentTargetedCell
        {
            get
            {
                return _currentTargetedCell;
            }
            set
            {
                if (_currentTargetedCell != value)
                {
                    _currentTargetedCell = value;
                    NewCellTarget(_currentTargetedCell);
                }

            }
        }

        private void NewCellTarget(Vector2 value)
        {
            var listContenu = new List<MapDrawableComponent>();
            listContenu.AddRange(this.fullBoard.Where(x=> x.positionCell == value));
            var desc = string.Join(" ", listContenu.Select(x => x.Description));
            log.WriteLine(desc);
        }


        public Map(GameEngine game, ILogPrinter lp, Vector2 size = default(Vector2))
            : base(game)
        {
            if (size == default(Vector2))
                size = new Vector2(50, 50);
            Game = game;
            log = lp;
            this.fullBoard = new ListGameAware<MapDrawableComponent>(game);
            SizeOfMap = size;
        }




        internal void HandleVisibility(LivingBeing being)
        {
            var posLb = being.positionCell;
            var listCell = Utilitaires.GetPathsToDistanceMax(posLb, being.statistics.FOV);
            HandleVisibilityOfList(being, listCell, fullBoard.FullDump());
        }

        private void HandleVisibilityOfList(LivingBeing being, List<List<Vector2>> listPathOfVisibility, List<MapDrawableComponent> listGameAware)
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

        public IEnumerable<Item> ItemsOnPosition(Vector2 targetPosition)
        {
            return fullBoard.Where<Item>(x => x.positionCell == targetPosition);
        }

        public Cell CellOnPosition(Vector2 targetposition)
        {
            return fullBoard.Where<Cell>(x => x.positionCell == targetposition).First();
        }

        public void RemoveLivingBeing(LivingBeing lb)
        {
            fullBoard.Remove(lb);
        }

        public void AddLivingBeing(LivingBeing lb, Vector2 pos)
        {
            lb.positionCell = pos;
            fullBoard.Add(lb);
        }

        public void RemoveItems(List<Item> it)
        {
            fullBoard.RemoveAll<Item>(it.Contains);
        }

        public void Pickup(LivingBeing lb)
        {
            var listObject = this.ItemsOnPosition(lb.positionCell).ToList();
            lb.Inventory.AddRange(listObject);
            RemoveItems(listObject);
        }

        public void ShowInventory(LivingBeing lb)
        {
            lb.DumpInventory();
        }

        public void DropFirstObject(LivingBeing lb)
        {
            var itemToDrop = lb.Inventory.FirstOrDefault(x => !x.IsEquipped);
            if (itemToDrop != null)
            {
                lb.Inventory.Remove(itemToDrop);
                itemToDrop.positionCell = lb.positionCell;
                fullBoard.Add(itemToDrop);
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
            fullBoard.IsActive = toActive;
        }
    }

}
