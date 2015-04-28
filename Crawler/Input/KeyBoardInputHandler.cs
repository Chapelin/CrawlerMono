namespace Crawler.Input
{
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Living;
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
            this.newPressed = this.currentKeyboardState.GetPressedKeys().Except(this.previousKeyboardState.GetPressedKeys()).ToList();
            if (newPressed.Any())
            {
                if (poolOfAction.ContainsAnActionFor(lb, this.newPressed))
                {
                    var action = poolOfAction.GetAction(lb, this.newPressed).Activity;
                    action(lb);
                }
            }
        }
       
    }
}
