namespace Crawler
{
    using System;
    using System.Linq;
    using System.Text;

    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework.Input;

    public class ActionDoable : IComparable
    {
        public string Name { get; set; }

        public ActionToDo Activity { get; set; }

        public Keys[] Bind { get; set; }

        public string KeyBinding
        {
            get
            {
                var str = new StringBuilder();
                foreach (var keyse in this.Bind.OrderBy(x=> x.GetHashCode()))
                {
                    str.Append(Enum.GetName(typeof(Keys), keyse)).Append(" ");
                }

                return str.ToString();
            }
        }

        public int CompareTo(object obj)
        {
            return this.GetHashCode() - obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Bind.Sum(x => x.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return this.CompareTo(obj) == 0;
        }
    }

    public delegate void ActionToDo(LivingBeing lb);

}
