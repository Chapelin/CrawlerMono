using System.Linq;

namespace Crawler
{
    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class InputHandler
    {
        private Keys lastPressedKey;

        private int timer;

        private Camera c;

        private Map m;

        public InputHandler(Camera c, Map m)
        {
            this.timer = 30;
            this.c = c;
            this.m = m;
        }


        public void HandleKeyboard(LivingBeing lb)
        {
            var k = Keyboard.GetState();
            if (this.timer > 0)
            {
                this.timer--;
            }
            if (k.GetPressedKeys().Any())
            {
                if (this.timer == 0)
                {
                    this.HandleKeyboardPlayerMovement(k, lb);

                    if (k.GetPressedKeys().Contains(Keys.P))
                    {
                        Pickup(lb);
                    }
                }

                if (k.GetPressedKeys().Contains(Keys.Space))
                {
                    this.c.CenterOn(lb.positionCell);
                }

            }
        }

        private void Pickup(LivingBeing lb)
        {
            var listObject = this.m.ItemOnPosition(lb.positionCell).ToList();
            lb.Inventory.AddRange(listObject);
            this.m.RemoveItem(listObject);
            lb.DumpInventory();
        }

        private void HandleKeyboardPlayerMovement(KeyboardState k, LivingBeing lb)
        {
            var targetCell = lb.positionCell;
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
            if (targetCell != lb.positionCell)
            {
                var targetCellObject = this.m.CellOnPosition(targetCell);
                if (null != targetCellObject)
                {
                    if (targetCellObject.IsWalkable(lb))
                    {
                        this.m.MoveBeing(lb, targetCell);
                        this.timer = 30;
                    }
                }
            }
        }
    }
}
