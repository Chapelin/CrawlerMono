﻿namespace Crawler.Input
{
    using System;
    using System.Linq;

    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class KeyBoardInputHandler
    {

        private int TimerResetValue = 30;
        private int timer;

        public KeyBoardInputHandler()
        {
            this.ResetTimer();
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

            }

        }

        private void HandleKeyboardPlayerMenu(KeyboardState k, LivingBeing lb)
        {
            if (k.GetPressedKeys().Contains(Keys.P))
            {
                BlackBoard.CurrentMap.Pickup(lb);
                this.ResetTimer();
            }

            if (k.GetPressedKeys().Contains(Keys.I))
            {
               BlackBoard.CurrentMap.ShowInventory(lb);
                this.ResetTimer();
            }

            if (k.GetPressedKeys().Contains(Keys.D))
            {
                BlackBoard.CurrentMap.DropFirstObject(lb);
                this.ResetTimer();

            }

            if (k.GetPressedKeys().Contains(Keys.Space))
            {
                BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell);
            }

            if (k.GetPressedKeys().Contains(Keys.L))
            {
                Console.WriteLine("Action dispos : ");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                foreach (var actionDoable in listAction)
                {
                    Console.WriteLine(actionDoable.ActionName);
                }
            }

            if (k.GetPressedKeys().Contains(Keys.A))
            {
                Console.WriteLine("Doing first action dispo");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                if (listAction.Any())
                {
                    listAction.First().ActionActivity.Invoke();
                }
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
                var res = BlackBoard.CurrentMap.TryMoveLivingBeing(lb, targetCell);
                if (res)
                {
                    this.ResetTimer();
                }
            }
        }
    }
}
