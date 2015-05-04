namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework.Input;

    public class ActionsPool
    {
        private Dictionary<Guid, List<ActionDoable>> PossibleActions { get; set; }

        public ActionsPool()
        {
            this.PossibleActions = new Dictionary<Guid, List<ActionDoable>>();
        }

        public void Register(LivingBeing lb, ActionDoable action)
        {
            if (!PossibleActions.ContainsKey(lb.UniqueIdentifier))
            {
                PossibleActions.Add(lb.UniqueIdentifier, new List<ActionDoable>());
            }

            PossibleActions[lb.UniqueIdentifier].Add(action);
        }

        public void Register(LivingBeing lb, IEnumerable<ActionDoable> action)
        {
            if (!PossibleActions.ContainsKey(lb.UniqueIdentifier))
            {
                PossibleActions.Add(lb.UniqueIdentifier, new List<ActionDoable>());
            }

            PossibleActions[lb.UniqueIdentifier].AddRange(action);
        }

        public void UnRegister(LivingBeing lb, ActionDoable action)
        {
            PossibleActions[lb.UniqueIdentifier].Remove(action);
        }

        public bool ContainsAnActionFor(LivingBeing lb,IEnumerable<Keys> keys)
        {
            return this.PossibleActions.ContainsKey(lb.UniqueIdentifier) &&
                   this.PossibleActions[lb.UniqueIdentifier].Any(x=> x.Bind.All(keys.Contains) );
        }

        public ActionDoable GetAction(LivingBeing lb, IEnumerable<Keys> keys)
        {
            return this.PossibleActions[lb.UniqueIdentifier].Where(x=> x.Bind.All(keys.Contains)).OrderByDescending(x=> x.Bind.Length).First();
        }

        public void UnRegister(LivingBeing lb, IEnumerable<ActionDoable> action)
        {
            PossibleActions[lb.UniqueIdentifier].RemoveAll(action.Contains);
        }

        public IEnumerable<ActionDoable> GetListOfAction(LivingBeing lb)
        {
            return PossibleActions[lb.UniqueIdentifier];
        }
    }
}
