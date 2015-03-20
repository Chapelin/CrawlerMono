using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crawler
{
    public class Cell : MapDrawableComponent
    {
        public bool IsWalkable { get; set; }

        public Cell(Game1 game, Vector2 p, bool w, Camera c)
            : base(game,p,c)
        {
            string sprite = "sprite\\";
            this.IsWalkable = w;
            sprite += (this.IsWalkable ? "floor" : "wall");
            this.sprite = game.Content.Load<Texture2D>(sprite);
        }

    }
}
