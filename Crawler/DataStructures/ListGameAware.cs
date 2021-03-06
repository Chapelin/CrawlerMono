﻿namespace Crawler.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Engine;

    public class ListGameAware<T>  where T: MapComponent
    {
        private List<T> innerList;

        private bool _isactive;
        public bool IsActive
        {
            set
            {
                if (this._isactive != value)
                {
                    if (value)
                    {
                        foreach (var elem in this.innerList)
                        {
                            elem.RegisterDrawingComponant();
                        }
                    }
                    else
                    {
                        foreach (var elem in this.innerList)
                        {
                           elem.UnregisterDrawingComponant();
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
            this.innerList = new List<T>();
        }

        public void Add(T obj)
        {
            this.innerList.Add(obj);
            if(this._isactive)
               obj.RegisterDrawingComponant();
        }

        public void Remove(T obj)
        {
            this.innerList.Remove(obj);
            if (this._isactive)
                obj.UnregisterDrawingComponant();
        }

        public void RemoveAt(int index)
        {
            var toRemove = this.innerList[index];
            this.innerList.RemoveAt(index);
            if (this._isactive)
                toRemove.UnregisterDrawingComponant();
        }

        public void RemoveAll<T1>(Predicate<T> match)
        {
            var elementToRemove = this.innerList.FindAll(match).Where(x => x is T1);
            this.innerList.RemoveAll(elementToRemove.Contains);
            if (this._isactive)
            {
                foreach (var el in elementToRemove)
                {
                   el.UnregisterDrawingComponant();
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
