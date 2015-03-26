namespace Crawler
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    public class ListGameAware<T> : List<T> where T: GameComponent
    {
        private Game1 Game;
        public ListGameAware(Game1 g)
        {
            this.Game = g;
        }

        public void Add(T obj)
        {
            base.Add(obj);
            this.Game.Components.Add(obj);
        }

        public void Remove(T obj)
        {
            base.Remove(obj);
            this.Game.Components.Remove(obj);
        }

        public void RemoveAt(int index)
        {
            var toRemove = base[index];
            base.RemoveAt(index);
            this.Game.Components.Remove(toRemove);
        }

        public void RemoveAll(Predicate<T> match)
        {
            var elementToRemove = this.FindAll(match);
            base.RemoveAll(match);
            foreach (var el in elementToRemove)
            {
                this.Game.Components.Remove(el);
            }
        }

        public void RemoveList(List<T> itemsToRemove)
        {
            base.RemoveAll(itemsToRemove.Contains);
            foreach (var item in itemsToRemove)
            {
                this.Game.Components.Remove(item);

            }

        }


    }
}
