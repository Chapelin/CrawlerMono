namespace Crawler
{
    using System.Linq;

    using Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class KeyBoardInputHandler
    {

        private int TimerResetValue = 30;
        private int timer;

        private Camera c;
        private GameEngine Game;

        private Map m;

        public KeyBoardInputHandler(Camera c, Map m, GameEngine game)
        {
            this.ResetTimer();
            this.c = c;
            this.m = m;
            this.Game = game;
        }

        private void ResetTimer()
        {
            this.timer = this.TimerResetValue;
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

                    this.HandleKeyboardPlayerMenu(k, lb);
                }

                if (k.GetPressedKeys().Contains(Keys.Space))
                {
                    this.c.CenterOn(lb.positionCell);
                }

            }
        }

        private void HandleKeyboardPlayerMenu(KeyboardState k, LivingBeing lb)
        {
            if (k.GetPressedKeys().Contains(Keys.P))
            {
                this.m.Pickup(lb);
                this.ResetTimer();
            }

            if (k.GetPressedKeys().Contains(Keys.I))
            {
               this.m.ShowInventory(lb);
                this.ResetTimer();
            }

            if (k.GetPressedKeys().Contains(Keys.D))
            {
                this.m.DropFirstObject(lb);
                this.ResetTimer();

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
                        this.Game.MoveBeing(lb, targetCell);
                        this.ResetTimer();
                    }
                }
            }
        }
    }
}
