namespace Crawler.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Cells;
    using DataStructures;
    using Items;
    using Living;
    using UI;
    using Utils;

    using Microsoft.Xna.Framework;

    public class Map : DrawableGameComponent
    {
        public ListGameAware<MapDrawableComponent> fullBoard; 
        //public ListGameAware<Cell> board;

        //public ListGameAware<Item> itemsOnBoard;

        //public ListGameAware<LivingBeing> livingOnMap;
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
            //
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
            HandleVisibilityOfList(being, listCell, fullBoard);
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
            return fullBoard.Where(x => x.positionCell == targetPosition).Where(x => x is Item).Cast<Item>();
        }

        public Cell CellOnPosition(Vector2 targetposition)
        {
            return (Cell) fullBoard.Where(x => x.positionCell == targetposition).First(x => x is Cell);
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
            fullBoard.RemoveList<Item>(it.Cast<MapDrawableComponent>().ToList());
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
