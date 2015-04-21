using System.Linq;

namespace Crawler.DataStructures
{
    using System;
    using System.Collections.Generic;

    using Crawler.Items;

    using Engine;

    using Microsoft.Xna.Framework;

    public class ListGameAware<T>  where T: GameComponent
    {

        private List<T> innerList; 

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
                        foreach (var elem in this.innerList)
                        {
                            Game.Components.Add(elem);
                        }
                    }
                    else
                    {
                        foreach (var elem in this.innerList)
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
            this.innerList = new List<T>();
        }

        public void Add(T obj)
        {
            this.innerList.Add(obj);
            if(_isactive)
                Game.Components.Add(obj);
        }

        public void Remove(T obj)
        {
            this.innerList.Remove(obj);
            if (_isactive)
                Game.Components.Remove(obj);
        }

        public void RemoveAt(int index)
        {
            var toRemove = this.innerList[index];
            this.innerList.RemoveAt(index);
            if (_isactive)
                Game.Components.Remove(toRemove);
        }

        public void RemoveAll<T1>(Predicate<T> match)
        {
            var elementToRemove = this.innerList.FindAll(match).Where(x => x is T1);
            this.innerList.RemoveAll(elementToRemove.Contains);
            if (_isactive)
            {
                foreach (var el in elementToRemove)
                {
                    Game.Components.Remove(el);
                }
            }
        }
        
        public void AddRange<T1>(IEnumerable<T1> li) where T1 : T
        {
            this.innerList.AddRange(li);
        }

        public T First<T1>() where T1 : T
        {
            return this.innerList.First(x => x is T1);
        }

        public IEnumerable<T1> AllOf<T1>() where T1 : T
        {
            return this.innerList.Where(x => x is T1).Cast<T1>();

        }

        public IEnumerable<T> Where(Func<T, bool> func)
        {
            return this.innerList.Where(func);
        }

        public List<T> FullDump()
        {
            return this.innerList;
        }

        public IEnumerable<T1> Where<T1>(Func<T, bool> func)
        {
            var temp = this.innerList.Where(func);
            return temp.Where(x => x is T1).Cast<T1>();
        }
    }
}
