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
        private delegate void ActionToDo(LivingBeing lb);
        private KeyboardState previousKeyboardState;
        private KeyboardState currentKeyboardState;
        private List<Keys> newPressed;
        private Dictionary<Keys, ActionToDo> actionsBinded;

        private void InitializeActions()
        {
            #region general menu actions

            this.actionsBinded.Add(Keys.P, lb => BlackBoard.CurrentMap.Pickup(lb));
            this.actionsBinded.Add(Keys.I, lb => BlackBoard.CurrentMap.ShowInventory(lb));
            this.actionsBinded.Add(Keys.D, lb => BlackBoard.CurrentMap.DropFirstObject(lb));
            this.actionsBinded.Add(Keys.Space, lb => BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell));
            this.actionsBinded.Add(
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

            this.actionsBinded.Add(Keys.A, lb =>
            {
                Console.WriteLine("Doing first action dispo");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                if (listAction.Any())
                {
                    listAction.First().Activity.Invoke();
                }
            });

            this.actionsBinded.Add(Keys.E, lb =>
            {
                Console.WriteLine("Trying to equipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.CanEquip(lb));
                if (eq != null)
                {
                    eq.Equip(lb);
                }
            });

            this.actionsBinded.Add(Keys.U, lb =>
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
            this.actionsBinded.Add(Keys.NumPad2, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(0, 1)));
            this.actionsBinded.Add(Keys.NumPad4, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, 0)));
            this.actionsBinded.Add(Keys.NumPad8, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(0, -1)));
            this.actionsBinded.Add(Keys.NumPad6, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, 0)));
            this.actionsBinded.Add(Keys.NumPad7, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, -1)));
            this.actionsBinded.Add(Keys.NumPad1, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, 1)));
            this.actionsBinded.Add(Keys.NumPad3, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, 1)));
            this.actionsBinded.Add(Keys.NumPad9, lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, -1)));

            #endregion playerMovement

        }

        public void HandleInput(LivingBeing lb)
        {
            this.previousKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();
            this.newPressed = this.currentKeyboardState.GetPressedKeys().Except(this.previousKeyboardState.GetPressedKeys()).ToList();


            if (this.actionsBinded.Any(x => this.newPressed.Contains(x.Key)))
            {
                var action = this.actionsBinded.FirstOrDefault(x => this.newPressed.Contains(x.Key)).Value;
                action(lb);
            }

        }

        public KeyBoardInputHandler()
        {
            this.actionsBinded = new Dictionary<Keys, ActionToDo>();
            this.InitializeActions();
        }
    }
}
