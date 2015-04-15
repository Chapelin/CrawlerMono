namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.Xna.Framework;

    public class SortedDictionnaryGameAware<T> where T : IGameComponent
    {
        private SortedDictionary<Vector2, List<T>> _dictionnary;

        private GameEngine g;


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
                        foreach (var elem in this._dictionnary.Keys)
                        {
                            var list = this.GetElementAt(elem);
                            list.ForEach(x => this.Register(x));
                        }
                    }
                    else
                    {
                        foreach (var elem in this._dictionnary.Keys)
                        {
                            var list = this.GetElementAt(elem);
                            list.ForEach(x => this.Unregister(x));
                        }
                    }
                    _isactive = value;
                }
            }
        }

        public SortedDictionnaryGameAware(GameEngine g)
        {
            this.g = g;
            this._dictionnary = new SortedDictionary<Vector2, List<T>>();
        }

        public void Add(Vector2 position, T obje)
        {
            if (!this._dictionnary.ContainsKey(position))
            {
                this._dictionnary.Add(position, new List<T>());
            }
            this._dictionnary[position].Add(obje);
            if (_isactive)
                this.Register(obje);

        }

        public void Remove(Vector2 position, T obect)
        {
            if (!this._dictionnary[position].Contains(obect))
                throw new Exception("Not found");
            this._dictionnary[position].Remove(obect);
            if (_isactive)
                this.Unregister(obect);
        }

        public void RemoveAll(Vector2 position)
        {
            if (_isactive)
            {
                this._dictionnary[position].ForEach(x => this.Unregister(x));
            }
            this._dictionnary[position].Clear();
        }

        public List<T> GetElementAt(Vector2 pos)
        {
            return this._dictionnary[pos];
        }

        public List<T> GetElementWhere(Func<T, bool> obPredicate)
        {
            var element = new List<T>();
            foreach (var val in this._dictionnary.Values)
            {
                Debug.Assert(obPredicate != null, "obPredicate != null");
                element.AddRange(val.Where(obPredicate));
            }
            return element;
        }

        private void Register(T obj)
        {
            this.g.Components.Add(obj);
        }

        private void Unregister(T obj)
        {
            this.g.Components.Remove(obj);
        }

    }
}
