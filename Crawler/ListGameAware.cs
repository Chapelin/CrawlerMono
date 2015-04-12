namespace Crawler
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    public class ListGameAware<T> : List<T> where T: GameComponent
    {

        private bool _isactive;
        public bool IsActive
        {
            get { return _isactive; }
            set
            {
                if (_isactive != value)
                {
                    if (value)
                    {
                        foreach (var elem in this)
                        {
                            Game.Components.Add(elem);
                        }
                    }
                    else
                    {
                        foreach (var elem in this)
                        {
                            Game.Components.Remove(elem);
                        }
                    }
                    _isactive = value;
                }
            }
        }
        private GameEngine Game;
        public ListGameAware(GameEngine g)
        {
            _isactive = false;
            Game = g;
        }

        public void Add(T obj)
        {
            base.Add(obj);
            if(_isactive)
                Game.Components.Add(obj);
        }

        public void Remove(T obj)
        {
            base.Remove(obj);
            if (_isactive)
                Game.Components.Remove(obj);
        }

        public void RemoveAt(int index)
        {
            var toRemove = base[index];
            base.RemoveAt(index);
            if (_isactive)
                Game.Components.Remove(toRemove);
        }

        public void RemoveAll(Predicate<T> match)
        {
            var elementToRemove = FindAll(match);
            base.RemoveAll(match);
            if (_isactive)
            {
                foreach (var el in elementToRemove)
                {
                    Game.Components.Remove(el);
                }
            }
        }

        public void RemoveList(List<T> itemsToRemove)
        {
            base.RemoveAll(itemsToRemove.Contains);
            if (_isactive)
            {
                foreach (var item in itemsToRemove)
                {
                    Game.Components.Remove(item);

                }
            }

        }


    }
}
