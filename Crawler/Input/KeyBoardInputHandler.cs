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
            #region general menu actions

            actionsBinded.Add(Keys.P, lb => BlackBoard.CurrentMap.Pickup(lb));
            actionsBinded.Add(Keys.I, lb => BlackBoard.CurrentMap.ShowInventory(lb));
            actionsBinded.Add(Keys.D, lb => BlackBoard.CurrentMap.DropFirstObject(lb));
            actionsBinded.Add(Keys.Space, lb => BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell));
            actionsBinded.Add(
                Keys.L,
                lb =>
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

            #endregion general menu actions

            #region playerMovement
            actionsBinded.Add(Keys.NumPad2, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(0, 1)));
            actionsBinded.Add(Keys.NumPad4, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, 0)));
            actionsBinded.Add(Keys.NumPad8, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(0, -1)));
            actionsBinded.Add(Keys.NumPad6, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, 0)));
            actionsBinded.Add(Keys.NumPad7, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, -1)));
            actionsBinded.Add(Keys.NumPad1, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, 1)));
            actionsBinded.Add(Keys.NumPad3, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, 1)));
            actionsBinded.Add(Keys.NumPad9, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, -1)));

            #endregion playerMovement

        }

        public void HandleInput(LivingBeing lb)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            newPressed = currentKeyboardState.GetPressedKeys().Except(previousKeyboardState.GetPressedKeys()).ToList();


            if (actionsBinded.Any(x => newPressed.Contains(x.Key)))
            {
                var action = this.actionsBinded.FirstOrDefault(x => newPressed.Contains(x.Key)).Value;
                action(lb);
            }

        }

        public KeyBoardInputHandler()
        {
            this.actionsBinded = new Dictionary<Keys, ActionToDo>();
            InitializeActions();
        }
    }
}
