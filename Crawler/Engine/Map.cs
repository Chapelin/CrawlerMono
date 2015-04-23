using Crawler.Helpers;

namespace Crawler.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using Cells;
    using DataStructures;
    using Items;
    using Living;
    using UI;

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
            listContenu.AddRange(fullBoard.Where(x=> x.positionCell == value));
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
            fullBoard = new ListGameAware<MapDrawableComponent>(game);
            SizeOfMap = size;
        }

        internal void HandleVisibility(LivingBeing being)
        {
            VisibilityHandler.HandleVisibilityOfList(being, fullBoard.FullDump());
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
            var listObject = ItemsOnPosition(lb.positionCell).ToList();
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

        public bool TryMoveLivingBeingToPosition(LivingBeing lb, Vector2 targetPosition)
        {
            var retour = false;
            var targetCellObject = CellOnPosition(targetPosition);
            if (null != targetCellObject)
            {
                if (targetCellObject.IsWalkable(lb))
                {
                    Game.MoveBeing(lb, targetPosition);
                    retour = true;
                }
            }
            return retour;
        }

        public bool TryMoveLivingBeingOfVector(LivingBeing lb, Vector2 deplacementVector)
        {
            return TryMoveLivingBeingToPosition(lb,lb.positionCell + deplacementVector);
        }

        public void SetAsActive(bool toActive)
        {
            fullBoard.IsActive = toActive;
        }
    }

}
