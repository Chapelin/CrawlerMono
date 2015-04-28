using System;
using Microsoft.Xna.Framework.Input;

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

            RegisterActions(b);

            m.fullBoard.Add(b);
            b.IsUserControlled = false;
            return b;
        }

        private static void RegisterActions(LivingBeing b)
        {
            var l = new List<ActionDoable>()
            {
                new ActionDoable()
                {
                    Activity = lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(0, 1)),
                    Bind = new[] {Keys.NumPad2},
                    Name = "Move south"
                },
                new ActionDoable()
                {
                    Activity = lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, 0)),
                    Name = "Move east",
                    Bind = new[] {Keys.NumPad4}
                },
                new ActionDoable()
                {
                    Activity = lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(0, -1)),
                    Name = "Move north",
                    Bind = new[] {Keys.NumPad8}
                },
                new ActionDoable()
                {
                    Activity = lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, 0)),
                    Name = "Move west",
                    Bind = new[] {Keys.NumPad6}
                },
                new ActionDoable()
                {
                    Activity = lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, -1)),
                    Name = "Move NE",
                    Bind = new[] {Keys.NumPad7}
                },
                new ActionDoable()
                {
                    Activity = lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, 1)),
                    Name = "Move SE",
                    Bind = new[] {Keys.NumPad1}
                },
                new ActionDoable()
                {
                    Activity = lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, 1)),
                    Name = "Move SW",
                    Bind = new[] {Keys.NumPad3}
                },
                new ActionDoable()
                {
                    Activity = lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, -1)),
                    Name = "Move NW",
                    Bind = new[] {Keys.NumPad9}
                }
            };

            BlackBoard.Pool.Register(b, l);

            var la = new List<ActionDoable>()
            {
                new ActionDoable(){Activity = lb => BlackBoard.CurrentMap.Pickup(lb), Bind = new []{Keys.P}, Name = "Pickup objects"},
                new ActionDoable(){Activity = lb => BlackBoard.CurrentMap.ShowInventory(lb), Bind = new []{Keys.I}, Name = "Show inventory"},
                new ActionDoable(){Activity = lb => BlackBoard.CurrentMap.DropFirstObject(lb), Bind = new []{Keys.D}, Name = "Drop object"},
                new ActionDoable(){Activity = lb => BlackBoard.CurrentCamera.CenterOnCell(lb.positionCell), Bind = new []{Keys.Space}, Name = "Center view"},
                new ActionDoable(){Activity =  lb =>{
                        Console.WriteLine("Action dispos : ");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                foreach (var actionDoable in listAction)
                {
                    Console.WriteLine(actionDoable.Name + " " + actionDoable.KeyBinding);
                }
            }, Bind = new []{Keys.L}, Name = "Action list"},
              new ActionDoable(){Activity =  lb =>{
                          Console.WriteLine("Doing first action dispo");
                var listAction = BlackBoard.CurrentMap.CellOnPosition(lb.positionCell).PossibleActions(lb);
                if (listAction.Any())
                {
                    listAction.First().Activity.Invoke(lb);
                }
            }, Bind = new []{Keys.A}, Name = "First action"},
            
            new ActionDoable(){Activity =  lb =>{
                            Console.WriteLine("Trying to equipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.CanEquip(lb));
                if (eq != null)
                {
                    eq.Equip(lb);
                }
            }, Bind = new []{Keys.E}, Name = "Equip"},  
            
            new ActionDoable(){Activity =  lb => {
                Console.WriteLine("Trying to unequipe first item");
                var eq = lb.Inventory.FirstOrDefault(x => x.IsEquipped);
                if (eq != null)
                {
                    eq.UnEquip(lb);
                }
            }, Bind = new []{Keys.U}, Name = "UnEquip"},
            };
            BlackBoard.Pool.Register(b, la);
        }

        public static LivingBeing InitializePlayer(Map m, ILogPrinter lp)
        {
            var position = m.fullBoard.First<Floor>().positionCell;
            var human = new Human(m.Game, position, lp) { IsUserControlled = true };
            RegisterActions(human);
            m.fullBoard.Add(human);
            return human;
        }
    }
}
