using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// The potion.
    /// </summary>
    public class Potion : Item.Item
    {
        public Potion(Game1 game, Vector2 positionCell, Camera c, string spriteName, SpriteBatch sb)
            : base(game, positionCell, c, sb)
        {
            this.sprite = game.Content.Load<Texture2D>(spriteName);
        }
    }
}
