namespace Crawler
{
    using System;
    using System.Text;

    using Microsoft.Xna.Framework.Input;

    public class ActionDoable
    {
        public string Name { get; set; }

        public Action Activity { get; set; }

        public Keys[] Bind { get; set; }

        public string KeyBinding
        {
            get
            {
                var str = new StringBuilder();
                foreach (var keyse in Bind)
                {
                    str.Append(Enum.GetName(typeof(Keys), keyse)).Append(" ");
                }
                return str.ToString();
            }
        }
    }
}
