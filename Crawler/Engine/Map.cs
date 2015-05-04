using Crawler.Helpers;

namespace Crawler.Engine
{
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Cells;
    using Crawler.DataStructures;
    using Crawler.GameObjects.Items;
    using Crawler.GameObjects.Living;
    using Crawler.UI;

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
                return this._currentTargetedCell;
            }

            set
            {
                if (this._currentTargetedCell != value)
                {
                    this._currentTargetedCell = value;
                    this.NewCellTarget(this._currentTargetedCell);
                }
            }
        }

        private void NewCellTarget(Vector2 value)
        {
            var listContenu = new List<MapDrawableComponent>();
            listContenu.AddRange(this.fullBoard.Where(x=> x.positionCell == value));
            var desc = string.Join(" ", listContenu.Select(x => x.Description));
            this.log.WriteLine(desc);
        }


        public Map(GameEngine game, ILogPrinter lp, Vector2 size = default(Vector2))
            : base(game)
        {
            if (size == default(Vector2))
                size = new Vector2(50, 50);
            this.Game = game;
            this.log = lp;
            this.fullBoard = new ListGameAware<MapDrawableComponent>(game);
            this.SizeOfMap = size;
        }

        internal void HandleVisibility(LivingBeing being)
        {
            VisibilityHandler.HandleVisibilityOfList(being, this.fullBoard.FullDump());
        }

        public IEnumerable<Item> ItemsOnPosition(Vector2 targetPosition)
        {
            return this.fullBoard.Where<Item>(x => x.positionCell == targetPosition);
        }

        public Cell CellOnPosition(Vector2 targetposition)
        {
            return this.fullBoard.Where<Cell>(x => x.positionCell == targetposition).First();
        }

        public void RemoveLivingBeing(LivingBeing lb)
        {
            this.fullBoard.Remove(lb);
        }

        public void AddLivingBeing(LivingBeing lb, Vector2 pos)
        {
            lb.positionCell = pos;
            this.fullBoard.Add(lb);
        }

        public void RemoveItems(List<Item> it)
        {
            this.fullBoard.RemoveAll<Item>(it.Contains);
        }

        public void Pickup(LivingBeing lb)
        {
            var listObject = this.ItemsOnPosition(lb.positionCell).ToList();
            lb.Inventory.AddRange(listObject);
            this.RemoveItems(listObject);
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
                this.fullBoard.Add(itemToDrop);
            }
        }

        public bool TryMoveLivingBeingToPosition(LivingBeing lb, Vector2 targetPosition)
        {
            var retour = false;
            var targetCellObject = this.CellOnPosition(targetPosition);
            if (null != targetCellObject)
            {
                if (targetCellObject.IsWalkable(lb))
                {
                    this.Game.MoveBeing(lb, targetPosition);
                    retour = true;
                }
            }

            return retour;
        }

        public bool TryMoveLivingBeingOfVector(LivingBeing lb, Vector2 deplacementVector)
        {
            return this.TryMoveLivingBeingToPosition(lb, lb.positionCell + deplacementVector);
        }

        public void SetAsActive(bool toActive)
        {
            this.fullBoard.IsActive = toActive;
        }
    }

}
