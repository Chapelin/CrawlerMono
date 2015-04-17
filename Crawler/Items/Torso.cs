﻿namespace Crawler.Items
{
    using Components.ItemRelated.Implementation;
    using Engine;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Torso : Equipable
    {
        public Torso(GameEngine game, Vector2 positionCell, Camera c, SpriteBatch sb)
            : base(game, positionCell, c, sb, new BasicEquipableItem(new StatisticModifierFOv()), "sprite\\torso")
        {
        }

        public override string Description
        {
            get
            {
                return "An armor";
            }
        }
    }
}
