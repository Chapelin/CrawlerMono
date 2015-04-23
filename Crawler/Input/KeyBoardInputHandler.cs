using System.Collections.Generic;

namespace Crawler.Input
{
    using System;
    using System.Linq;

    using Crawler.Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class KeyBoardInputHandler
    {
        private KeyboardState previousKeyboardState;
        private KeyboardState currentKeyboardState;
        private List<Keys> newPressed;

        public KeyBoardInputHandler()
        {
        }


        public void HandleInput(LivingBeing lb)
        {
            previousKeyboardState = currentKeyboardState;
          currentKeyboardState = Keyboard.GetState();
            newPressed = currentKeyboardState.GetPressedKeys().Except(previousKeyboardState.GetPressedKeys()).ToList();


            if (newPressed.Any())
            {
           
                    this.HandleKeyboardPlayerMovement (lb);

                    this.HandleKeyboardPlayerMenu( lb);
                

            }

        }

        private void HandleKeyboardPlayerMenu(LivingBeing lb)
        {
            if (newPressed.Contains(Keys.P))
            {
                BlackBoard.CurrentMap.Pickup(lb);
            }

            if (newPressed.Contains(Keys.I))
            {
                BlackBoard.CurrentMap.ShowInventory(lb);
            }

            if (newPressed.Contains(Keys.D))
            {
                BlackBoard.CurrentMap.DropFirstObject(lb);
            }

            if (newPressed.Contains(Keys.Space))
            {
                BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell);
            }

            if (newPressed.Contains(Keys.L))
            {
                Console.WriteLine("Action dispos : ");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                foreach (var actionDoable in listAction)
                {
                    Console.WriteLine(actionDoable.Name + " " + actionDoable.KeyBinding);
                }
            }

            if (newPressed.Contains(Keys.A))
            {
                Console.WriteLine("Doing first action dispo");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                if (listAction.Any())
                {
                    listAction.First().Activity.Invoke();
                }
            }

            if (newPressed.Contains(Keys.E))
            {
                Console.WriteLine("Trying to equipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.CanEquip(lb));
                if (eq != null)
                {
                    eq.Equip(lb);
                }
            }

            if (newPressed.Contains(Keys.U))
            {
                Console.WriteLine("Trying to unequipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.IsEquipped);
                if (eq != null)
                {
                    eq.UnEquip(lb);
                }
            }
        }

        private void HandleKeyboardPlayerMovement(LivingBeing lb)
        {
            var targetCell = lb.positionCell;
            if (newPressed.Contains(Keys.NumPad2))
            {
                targetCell.Y++;
            }

            if (newPressed.Contains(Keys.NumPad4))
            {
                targetCell.X--;
            }

            if (newPressed.Contains(Keys.NumPad8))
            {
                targetCell.Y--;
            }

            if (newPressed.Contains(Keys.NumPad6))
            {
                targetCell.X++;
            }

            if (newPressed.Contains(Keys.NumPad9))
            {
                targetCell += new Vector2(1, -1);
            }

            if (newPressed.Contains(Keys.NumPad7))
            {
                targetCell += new Vector2(-1, -1);
            }

            if (newPressed.Contains(Keys.NumPad1))
            {
                targetCell += new Vector2(-1, 1);
            }

            if (newPressed.Contains(Keys.NumPad3))
            {
                targetCell += new Vector2(1, 1);
            }

            if (targetCell != lb.positionCell)
            {
               BlackBoard.CurrentMap.TryMoveLivingBeing(lb, targetCell);
            }
        }
    }
}
