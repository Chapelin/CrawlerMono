namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Living;

    using Microsoft.Xna.Framework.Input;

    public class ActionsPool
    {
        private Dictionary<Guid, List<ActionDoable>> possibleActions { get; set; }

        public ActionsPool()
        {
            this.possibleActions = new Dictionary<Guid, List<ActionDoable>>();
        }

        public void Register(LivingBeing lb, ActionDoable action)
        {
            if (!possibleActions.ContainsKey(lb.uniqueIdentifier))
            {
                possibleActions.Add(lb.uniqueIdentifier, new List<ActionDoable>());
            }

            possibleActions[lb.uniqueIdentifier].Add(action);
        }

        public void Register(LivingBeing lb, IEnumerable<ActionDoable> action)
        {
            if (!possibleActions.ContainsKey(lb.uniqueIdentifier))
            {
                possibleActions.Add(lb.uniqueIdentifier, new List<ActionDoable>());
            }

            possibleActions[lb.uniqueIdentifier].AddRange(action);
        }

        public void UnRegister(LivingBeing lb, ActionDoable action)
        {
            possibleActions[lb.uniqueIdentifier].Remove(action);
        }

        public bool ContainsAnActionFor(LivingBeing lb,IEnumerable<Keys> keys)
        {
            return this.possibleActions.ContainsKey(lb.uniqueIdentifier) &&
                   this.possibleActions[lb.uniqueIdentifier].Any(x=> x.Bind.All(keys.Contains) );
        }

        public ActionDoable GetAction(LivingBeing lb, IEnumerable<Keys> keys)
        {
            return this.possibleActions[lb.uniqueIdentifier].Where(x=> x.Bind.All(keys.Contains)).OrderByDescending(x=> x.Bind.Length).First();
        }

        public void UnRegister(LivingBeing lb, IEnumerable<ActionDoable> action)
        {
            possibleActions[lb.uniqueIdentifier].RemoveAll(action.Contains);
        }

        public IEnumerable<ActionDoable> GetListOfAction(LivingBeing lb)
        {
            return possibleActions[lb.uniqueIdentifier];
        }
    }
}
