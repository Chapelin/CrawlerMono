namespace Crawler.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Cells;
    using Crawler.Engine;
    using Crawler.Items;
    using Crawler.Living;
    using Crawler.UI;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class MapFiller
    {

        public static void InitializeItems(Camera c, Map m, SpriteBatch sb)
        {
            var li = new List<Item>(){
                new Potion(m.Game, new Vector2(5, 5), c, sb),
                new Potion(m.Game, new Vector2(10, 5), c, sb),
                new Potion(m.Game, new Vector2(7, 2), c, sb),
                new Potion(m.Game, new Vector2(4, 11), c, sb),
                new Potion(m.Game, new Vector2(4, 11), c, sb),
                new Rod(m.Game, new Vector2(5, 5), c, sb)};

            var pos = m.board.Where(x => x.GetType() == typeof(Floor)).Select(y=> y.positionCell).Take(3);
            li.Add(new Torso(m.Game,pos.Last(),c,sb));
                
            m.itemsOnBoard.AddRange(li);
        }

        public static LivingBeing InitializeEnnemis(Camera c, Map m, SpriteBatch sb, ILogPrinter log)
        {
            var b = new Bat(m.Game, new Vector2(1, 1), c, sb, log);
            m.livingOnMap.Add(b);
            b.IsUserControlled = false;
            return b;
        }

        public static LivingBeing InitializePlayer(Camera c, Map m, SpriteBatch sb)
        {
            var position = m.board.First(x => x.GetType() == typeof(Floor)).positionCell;
            var human = new Human(m.Game, position, c, sb);
            human.IsUserControlled = true;
            m.livingOnMap.Add(human);
            return human;

        }
    }
}
