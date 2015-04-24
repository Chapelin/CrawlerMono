namespace Crawler
{
    using System;
    using System.Text;

    using Crawler.Input;

    using Microsoft.Xna.Framework.Input;

    public class ActionDoable
    {
        public string Name { get; set; }

        public KeyBoardInputHandler.ActionToDo Activity { get; set; }

        public Keys[] Bind { get; set; }

        public string KeyBinding
        {
            get
            {
                var str = new StringBuilder();
                foreach (var keyse in this.Bind)
                {
                    str.Append(Enum.GetName(typeof(Keys), keyse)).Append(" ");
                }

                return str.ToString();
            }
        }
    }
}
