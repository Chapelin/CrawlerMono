using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler.MapGenerator
{
    using Microsoft.Xna.Framework;

public class Exit
{
    public Vector2 Position;

    public bool IsUsed;

    public Exit()
    {
        this.IsUsed = false;
    }
}
}
