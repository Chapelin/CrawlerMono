using System.Linq;

namespace Crawler.DataStructures
{
    using System;
    using System.Collections.Generic;

    using Engine;

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

        public void RemoveAll<T1>(Predicate<T> match)
        {
            var elementToRemove = FindAll(match).Where(x=> x is T1);
            base.RemoveAll(elementToRemove.Contains);
            if (_isactive)
            {
                foreach (var el in elementToRemove)
                {
                    Game.Components.Remove(el);
                }
            }
        }

        public void RemoveList<T1>(List<T> itemsToRemove)
        {
            RemoveAll<T1>(itemsToRemove.Contains);
           

        }


    }
}
