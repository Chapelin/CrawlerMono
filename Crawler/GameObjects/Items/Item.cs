﻿namespace Crawler.GameObjects.Items
{
    using System;
    using System.Linq;

    using Crawler.Components.Actions;
    using Crawler.Components.ItemRelated;
    using Crawler.Engine;
    using Crawler.GameObjects.Living;

    using Microsoft.Xna.Framework;

    public class Item : MapComponent
    {
        protected IEquipableComponent equipableComponent;
        private IConsumableComponent cc;
        private IActivableComponent ac;
        public Item( Vector2 positionCell,  IEquipableComponent ec, IConsumableComponent cc, IActivableComponent ac )
            : base(positionCell)
        {
            this.VisitedColor = new Color(125, 125, 125);
            this.equipableComponent = ec;
            this.cc = cc;
            this.ac = ac;
        }

        public bool CanEquip(LivingBeing lb)
        {
            return this.equipableComponent.CanEquip(lb) && !this.IsEquipped;
        }

        public void Equip(LivingBeing lb)
        {
            this.equipableComponent.Equip(lb);
        }

        public void UnEquip(LivingBeing lb)
        {
            this.equipableComponent.UnEquip(lb);
        }

        public bool CanConsume(LivingBeing lb)
        {
            return this.cc.CanConsume(lb);
        }

        public void Consume(LivingBeing lb)
        {
            this.cc.Consume(lb);
        }

        public bool CanUse(LivingBeing lb)
        {
            return this.ac.Activables(lb).Any();
        }

        public bool IsEquipped
        {
            get
            {
                return this.equipableComponent.IsEquipped();
            }
        }

        public EquipementType Type
        {
            get
            {
                return this.equipableComponent.typeOfItem;
            }
        }

        [Flags]
        public enum EquipementType
        {
            Necklace = 0x1,
            OneHand,
            TwoHand,
            Helmet,
            Torso,
            Foot,
            Ring,
            Other
        }

    }
}
