using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Terrain
{
    public TileType type;
    public GameObject prefab;
    public int cost;
    private Color color;

    public Terrain()
    {
    }

    public Color Color
    {
        get
        {
            return color;
        }
        set
        {
            color = value;
        }
    }
}
