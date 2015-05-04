
namespace Crawler.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System;

    using Microsoft.Xna.Framework.Input;

    using Crawler.Cells;
    using Crawler.Engine;
    using Crawler.GameObjects.Effect.Implementations;
    using Crawler.GameObjects.Items;
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    /// <summary>
    /// The map filler.
    /// </summary>
    public static class MapFiller
    {
        /// <summary>
        /// The initialize items.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <param name="lp">
        /// The lp.
        /// </param>
        public static void InitializeItems(Map m)
        {
            var li = new List<Item> {
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

        /// <summary>
        /// The initialize ennemis.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <param name="log">
        /// The log.
        /// </param>
        /// <returns>
        /// The <see cref="LivingBeing"/>.
        /// </returns>
        public static void InitializeEnnemis(Map m)
        {
           InitializeBat(m,new Vector2(1,1));
          InitializeBat(m,new Vector2(4,5));
        }

        public static LivingBeing InitializeBat(Map m, Vector2 v)
        {
            var b = new Bat(m.Game,v);

            RegisterActions(b);

            m.fullBoard.Add(b);
            b.IsUserControlled = false;
            return b;
        }

        /// <summary>
        /// The register actions.
        /// </summary>
        /// <param name="b">
        /// The b.
        /// </param>
        private static void RegisterActions(LivingBeing b)
        {
            #region movement
            var l = new List<ActionDoable>
                        {
                            new ActionDoable
                                {
                                    Activity =
                                        lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(0, 1)),
                                    Bind = new[] { Keys.NumPad2 },
                                    Name = "Move south"
                                },
                            new ActionDoable
                                {
                                    Activity =
                                        lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, 0)),
                                    Name = "Move east",
                                    Bind = new[] { Keys.NumPad4 }
                                },
                            new ActionDoable
                                {
                                    Activity =
                                        lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(0, -1)),
                                    Name = "Move north",
                                    Bind = new[] { Keys.NumPad8 }
                                },
                            new ActionDoable
                                {
                                    Activity =
                                        lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, 0)),
                                    Name = "Move west",
                                    Bind = new[] { Keys.NumPad6 }
                                },
                            new ActionDoable
                                {
                                    Activity =
                                        lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, -1)),
                                    Name = "Move NE",
                                    Bind = new[] { Keys.NumPad7 }
                                },
                            new ActionDoable
                                {
                                    Activity =
                                        lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(-1, 1)),
                                    Name = "Move SE",
                                    Bind = new[] { Keys.NumPad1 }
                                },
                            new ActionDoable
                                {
                                    Activity =
                                        lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, 1)),
                                    Name = "Move SW",
                                    Bind = new[] { Keys.NumPad3 }
                                },
                            new ActionDoable
                                {
                                    Activity =
                                        lb => BlackBoard.CurrentMap.TryMoveLivingBeingOfVector(lb, new Vector2(1, -1)),
                                    Name = "Move NW",
                                    Bind = new[] { Keys.NumPad9 }
                                }
                        };
            #endregion movement

            #region Camera
            l.AddRange(new List<ActionDoable>
            {
               new ActionDoable
                                 {
                                     Activity =
                                         lb =>
                                         BlackBoard.CurrentCamera.CenterOnCell(
                                             lb.positionCell),
                                     Bind = new[] { Keys.Space },
                                     Name = "Center view"
                                 },
                        new ActionDoable
                                 {
                                     Activity =
                                         lb =>
                                         BlackBoard.CurrentCamera.Move(new Vector2(-1,0)),
                                     Bind = new[] { Keys.Left },
                                     Name = "Move camera left"
                                 },
                                   new ActionDoable
                                 {
                                     Activity =
                                         lb =>
                                         BlackBoard.CurrentCamera.Move(new Vector2(1,0)),
                                     Bind = new[] { Keys.Right },
                                     Name = "Move camera right"
                                 }, 
                                 new ActionDoable
                                 {
                                     Activity =
                                         lb =>
                                         BlackBoard.CurrentCamera.Move(new Vector2(0,-1)),
                                     Bind = new[] { Keys.U },
                                     Name = "Move camera up"
                                 },  
                                 new ActionDoable
                                 {
                                     Activity =
                                         lb =>
                                         BlackBoard.CurrentCamera.Move(new Vector2(0,1)),
                                     Bind = new[] { Keys.Down },
                                     Name = "Move camera down"
                                 },
            });
            #endregion Camera

            #region  misc
            l.AddRange(new List<ActionDoable>
                         {
                             new ActionDoable
                                 {
                                     Activity = lb => BlackBoard.CurrentMap.Pickup(lb),
                                     Bind = new[] { Keys.P },
                                     Name = "Pickup objects"
                                 },
                             new ActionDoable
                                 {
                                     Activity =
                                         lb => BlackBoard.CurrentMap.ShowInventory(lb),
                                     Bind = new[] { Keys.I },
                                     Name = "Show inventory"
                                 },
                             new ActionDoable
                                 {
                                     Activity =
                                         lb => BlackBoard.CurrentMap.DropFirstObject(lb),
                                     Bind = new[] { Keys.D },
                                     Name = "Drop object"
                                 },
                            
                             new ActionDoable
                                 {
                                     Activity = lb =>
                                         {
                                             Console.WriteLine("Action dispos : ");
                                             var listAction = BlackBoard.Pool.GetListOfAction(lb);
                                             foreach (var actionDoable in listAction)
                                             {
                                                 Console.WriteLine(
                                                     actionDoable.Name + " " + actionDoable.KeyBinding);
                                             }
                                         },
                                     Bind = new[] { Keys.L },
                                     Name = "Action list"
                                 }
                         });
            #endregion  misc

            #region debug

            l.AddRange(new List<ActionDoable>()
                         {
                             new ActionDoable
                                 {
                                     Activity = lb =>
                                         {
                                             Console.WriteLine("Trying to equipe first item");
                                             var eq = lb.Inventory.FirstOrDefault(x => x.CanEquip(lb));
                                             if (eq != null)
                                             {
                                                 eq.Equip(lb);
                                             }
                                         },
                                     Bind = new[] { Keys.E },
                                     Name = "Equip"
                                 },
                             new ActionDoable
                                 {
                                     Activity = lb =>
                                         {
                                             Console.WriteLine("Trying to unequipe first item");
                                             var eq = lb.Inventory.FirstOrDefault(x => x.IsEquipped);
                                             if (eq != null)
                                             {
                                                 eq.UnEquip(lb);
                                             }
                                         },
                                     Bind = new[] { Keys.U },
                                     Name = "UnEquip"
                                 },

                            new ActionDoable
                                 {
                                     Activity = lb =>
                                         {
                                             Console.WriteLine("Apply light magic");
                                             lb.AddEffect(new LightEffect(2));
                                         },
                                     Bind = new[] { Keys.S },
                                     Name = "Light"
                                 },
                             new ActionDoable
                                 {
                                     Activity = lb =>
                                         {
                                             Console.WriteLine("current effect on player");
                                             foreach (var eff in lb.CurrentEffect)
                                             {
                                                 Console.WriteLine("\t{0}",eff.Description);
                                             }
                                         },
                                     Bind = new[] { Keys.S, Keys.LeftShift },
                                     Name = "List effects"
                                 }, 
                                 new ActionDoable
                                 {
                                     Activity = lb =>
                                         {
                                             Console.WriteLine("add a bat");
                                             MapFiller.InitializeBat(BlackBoard.CurrentMap, lb.positionCell+ (new Vector2(1,0)));
                                         },
                                     Bind = new[] { Keys.B },
                                     Name = "Bat spawn"
                                 },

                         });

            #endregion debug

            BlackBoard.Pool.Register(b, l);

        }

        /// <summary>
        /// The initialize player.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <param name="lp">
        /// The lp.
        /// </param>
        /// <returns>
        /// The <see cref="LivingBeing"/>.
        /// </returns>
        public static LivingBeing InitializePlayer(Map m)
        {
            var position = m.fullBoard.First<Floor>().positionCell;
            var human = new Human(m.Game, position) { IsUserControlled = true };
            RegisterActions(human);
            m.fullBoard.Add(human);
            return human;
        }
    }
}
