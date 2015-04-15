using System;

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

        private Map m;

        public KeyBoardInputHandler(Camera c, Map m)
        {
            ResetTimer();
            this.c = c;
            this.m = m;
        }

        private void ResetTimer()
        {
            timer = TimerResetValue;
        }

        public void HandleInput(LivingBeing lb)
        {
            var k = Keyboard.GetState();
            if (timer > 0)
            {
                timer--;
            }
            if (k.GetPressedKeys().Any())
            {
                if (timer == 0)
                {
                    HandleKeyboardPlayerMovement(k, lb);

                    HandleKeyboardPlayerMenu(k, lb);
                }

            }
        }

        private void HandleKeyboardPlayerMenu(KeyboardState k, LivingBeing lb)
        {
            if (k.GetPressedKeys().Contains(Keys.P))
            {
                m.Pickup(lb);
                ResetTimer();
            }

            if (k.GetPressedKeys().Contains(Keys.I))
            {
               m.ShowInventory(lb);
                ResetTimer();
            }

            if (k.GetPressedKeys().Contains(Keys.D))
            {
                m.DropFirstObject(lb);
                ResetTimer();

            }

            if (k.GetPressedKeys().Contains(Keys.Space))
            {
                c.CenterOn(lb.positionCell);
            }

            if (k.GetPressedKeys().Contains(Keys.L))
            {
                Console.WriteLine("Action dispos : ");
                var listAction = m.CellOnPosition(lb.positionCell).PossibleActions(lb);
                foreach (var actionDoable in listAction)
                {
                    Console.WriteLine(actionDoable.ActionName);
                }
            }

            if (k.GetPressedKeys().Contains(Keys.A))
            {
                Console.WriteLine("Doing first action dispo");
                var listAction = m.CellOnPosition(lb.positionCell).PossibleActions(lb);
                if (listAction.Any())
                    listAction.First().ActionActivity.Invoke();
            }

            if (k.GetPressedKeys().Contains(Keys.E))
            {
                Console.WriteLine("Trying to equipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.CanEquip(lb));
                if (eq != null)
                {
                    eq.Equip(lb);
                }
            }

            if (k.GetPressedKeys().Contains(Keys.U))
            {
                Console.WriteLine("Trying to unequipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.IsEquipped);
                if (eq != null)
                {
                    eq.UnEquip(lb);
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
                var res = m.TryMoveLivingBeing(lb, targetCell);
                if (res)
                {
                    ResetTimer();
                }
            }
        }
    }
}
