namespace Crawler
{
    using System.Linq;

    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class KeyBoardInputHandler
    {

        private int timer;

        private Camera c;

        private Map m;

        public KeyBoardInputHandler(Camera c, Map m)
        {
            this.timer = 30;
            this.c = c;
            this.m = m;
        }


        public void HandleInput(LivingBeing lb)
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
                        this.m.Pickup(lb);
                    }
                }

                if (k.GetPressedKeys().Contains(Keys.Space))
                {
                    this.c.CenterOn(lb.positionCell);
                }

            }
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
