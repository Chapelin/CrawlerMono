namespace Crawler.DataStructures
{
    using System;
    using System.Collections.Generic;

    using Crawler.Engine;

    using Microsoft.Xna.Framework;

    public class ListGameAware<T> : List<T> where T: GameComponent
    {

        private bool _isactive;
        public bool IsActive
        {
            get { return this._isactive; }
            set
            {
                if (this._isactive != value)
                {
                    if (value)
                    {
                        foreach (var elem in this)
                        {
                            this.Game.Components.Add(elem);
                        }
                    }
                    else
                    {
                        foreach (var elem in this)
                        {
                            this.Game.Components.Remove(elem);
                        }
                    }
                    this._isactive = value;
                }
            }
        }
        private GameEngine Game;
        public ListGameAware(GameEngine g)
        {
            this._isactive = false;
            this.Game = g;
        }

        public void Add(T obj)
        {
            base.Add(obj);
            if(this._isactive)
                this.Game.Components.Add(obj);
        }

        public void Remove(T obj)
        {
            base.Remove(obj);
            if (this._isactive)
                this.Game.Components.Remove(obj);
        }

        public void RemoveAt(int index)
        {
            var toRemove = base[index];
            base.RemoveAt(index);
            if (this._isactive)
                this.Game.Components.Remove(toRemove);
        }

        public void RemoveAll(Predicate<T> match)
        {
            var elementToRemove = this.FindAll(match);
            base.RemoveAll(match);
            if (this._isactive)
            {
                foreach (var el in elementToRemove)
                {
                    this.Game.Components.Remove(el);
                }
            }
        }

        public void RemoveList(List<T> itemsToRemove)
        {
            base.RemoveAll(itemsToRemove.Contains);
            if (this._isactive)
            {
                foreach (var item in itemsToRemove)
                {
                    this.Game.Components.Remove(item);

                }
            }

        }


    }
}
