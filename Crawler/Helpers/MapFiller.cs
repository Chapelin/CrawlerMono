// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapFiller.cs" company="">
//
// </copyright>
// <summary>
//   The map filler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;

using Microsoft.Xna.Framework.Input;

namespace Crawler.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using Crawler.Cells;
    using Crawler.Engine;
    using Crawler.GameObjects.Effect.Implementations;
    using Crawler.GameObjects.Items;
    using Crawler.GameObjects.Living;
    using Crawler.UI;

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
        public static void InitializeItems(Map m, ILogPrinter lp)
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
        public static LivingBeing InitializeEnnemis(Map m, ILogPrinter log)
        {
            var b = new Bat(m.Game, new Vector2(1, 1), log);

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
            BlackBoard.Pool.Register(b, l);


            #region  misc
            var la = new List<ActionDoable>
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
                                     Activity =
                                         lb =>
                                         BlackBoard.CurrentCamera.CenterOnCell(
                                             lb.positionCell),
                                     Bind = new[] { Keys.Space },
                                     Name = "Center view"
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
                         };
            #endregion  misc
            BlackBoard.Pool.Register(b, la);

            #region debug

            var lm = new List<ActionDoable>()
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

                         };

            #endregion debug

            BlackBoard.Pool.Register(b, lm);
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
