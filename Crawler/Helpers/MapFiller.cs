﻿namespace Crawler.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using Cells;
    using Engine;
    using Items;
    using Living;
    using UI;

    using Microsoft.Xna.Framework;

    public static class MapFiller
    {


        public static void InitializeItems(Map m, ILogPrinter lp)
        {
            var li = new List<Item>(){
                new Potion(m.Game, new Vector2(5, 5)),
                new Potion(m.Game, new Vector2(10, 5)),
                new Potion(m.Game, new Vector2(7, 2)),
                new Potion(m.Game, new Vector2(4, 11)),
                new Potion(m.Game, new Vector2(4, 11)),
                new Rod(m.Game, new Vector2(5, 5))};

            var pos = m.fullBoard.AllOf<Floor>().Select(y => y.positionCell).Take(3);
            li.Add(new Torso(m.Game, pos.Last()));

            m.fullBoard.AddRange(li);
        }

        public static LivingBeing InitializeEnnemis(Map m, ILogPrinter log)
        {
            var b = new Bat(m.Game, new Vector2(1, 1), log);
            m.fullBoard.Add(b);
            b.IsUserControlled = false;
            return b;
        }

        public static LivingBeing InitializePlayer(Map m, ILogPrinter lp)
        {
            var position = m.fullBoard.First<Floor>().positionCell;
            var human = new Human(m.Game, position, lp) { IsUserControlled = true };
            m.fullBoard.Add(human);
            return human;
        }
    }
}
