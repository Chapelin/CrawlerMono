using System.Collections.Generic;

namespace Crawler.Input
{
    using System;
    using System.Linq;

    using Living;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class KeyBoardInputHandler
    {
        private delegate void ActionToDo(LivingBeing lb);
        private KeyboardState previousKeyboardState;
        private KeyboardState currentKeyboardState;
        private List<Keys> newPressed;
        private Dictionary<Keys, ActionToDo> actionsBinded;

        private void InitializeActions()
        {
            actionsBinded.Add(Keys.P, lb => BlackBoard.CurrentMap.Pickup(lb));
            actionsBinded.Add(Keys.I, lb => BlackBoard.CurrentMap.ShowInventory(lb));
            actionsBinded.Add(Keys.D, lb => BlackBoard.CurrentMap.DropFirstObject(lb));
            actionsBinded.Add(Keys.Space, lb => BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell));
            actionsBinded.Add(Keys.L, lb =>
            {
                Console.WriteLine("Action dispos : ");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                foreach (var actionDoable in listAction)
                {
                    Console.WriteLine(actionDoable.Name + " " + actionDoable.KeyBinding);
                }
            });

            actionsBinded.Add(Keys.A, lb =>
            {
                Console.WriteLine("Doing first action dispo");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                if (listAction.Any())
                {
                    listAction.First().Activity.Invoke();
                }
            });

            actionsBinded.Add(Keys.E, lb =>
            {
                Console.WriteLine("Trying to equipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.CanEquip(lb));
                if (eq != null)
                {
                    eq.Equip(lb);
                }
            });

            actionsBinded.Add(Keys.U, lb =>
            {
                Console.WriteLine("Trying to unequipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.IsEquipped);
                if (eq != null)
                {
                    eq.UnEquip(lb);
                }
            });


        }

        public void HandleInput(LivingBeing lb)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            newPressed = currentKeyboardState.GetPressedKeys().Except(previousKeyboardState.GetPressedKeys()).ToList();


            if (newPressed.Any())
            {
                this.HandleKeyboardPlayerMovement(lb);
                this.HandleKeyboardPlayerMenu(lb);
            }

        }

        private void HandleKeyboardPlayerMenu(LivingBeing lb)
        {
            if (actionsBinded.Any(x => newPressed.Contains(x.Key)))
            {
                var action = this.actionsBinded.FirstOrDefault(x => newPressed.Contains(x.Key)).Value;
                action(lb);
            }
        }

        private void HandleKeyboardPlayerMovement(LivingBeing lb)
        {
            var depVector = Vector2.Zero;

            if (newPressed.Contains(Keys.NumPad2))
            {
                depVector = new Vector2(0, 1);
            }

            if (newPressed.Contains(Keys.NumPad4))
            {
                depVector = new Vector2(-1, 0);
            }

            if (newPressed.Contains(Keys.NumPad8))
            {
                depVector = new Vector2(0, -1);
            }

            if (newPressed.Contains(Keys.NumPad6))
            {
                depVector = new Vector2(1, 0);
            }

            if (newPressed.Contains(Keys.NumPad9))
            {
                depVector = new Vector2(1, -1);
            }

            if (newPressed.Contains(Keys.NumPad7))
            {
                depVector = new Vector2(-1, -1);
            }

            if (newPressed.Contains(Keys.NumPad1))
            {
                depVector = new Vector2(-1, 1);
            }

            if (newPressed.Contains(Keys.NumPad3))
            {
                depVector = new Vector2(1, 1);
            }

            if (depVector != Vector2.Zero)
            {
                BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, depVector);
            }
        }

        public KeyBoardInputHandler()
        {
            this.actionsBinded = new Dictionary<Keys, ActionToDo>();
            InitializeActions();
        }
    }
}
