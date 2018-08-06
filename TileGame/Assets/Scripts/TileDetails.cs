using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TileDetails : Details
{
    Terrain terrain;

    public Terrain Terrain
    {
        get
        {
            return terrain;
        }

        set
        {
            terrain = value;
        }
    }
}
