using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Crawler.Utils.MapGenerator
{
    using Crawler.MapGenerator;

    public class Room
    {
        public Rectangle Setting;
        public List<Exit> IOs;

        public Room()
        {
            this.IOs = new List<Exit>();
        }
    }
}
