namespace Crawler.Input
{
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework.Input;

    public class KeyBoardInputHandler
    {
        private KeyboardState previousKeyboardState;
        private KeyboardState currentKeyboardState;
        private List<Keys> newPressed;

        public void HandleInput(LivingBeing lb, ActionsPool poolOfAction)
        {
            this.previousKeyboardState = this.currentKeyboardState;
            this.currentKeyboardState = Keyboard.GetState();
            var pressedKeys = this.currentKeyboardState.GetPressedKeys();
            if (pressedKeys.Except(this.previousKeyboardState.GetPressedKeys()).Any())
            {
                if (poolOfAction.ContainsAnActionFor(lb, pressedKeys))
                {
                    var action = poolOfAction.GetAction(lb, pressedKeys).Activity;
                    action(lb);
                }
            }
        }

    }
}
