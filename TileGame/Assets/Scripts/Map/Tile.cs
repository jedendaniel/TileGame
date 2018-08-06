using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Tile : IRepresentable
{
    Color normalColor;
    GameObject gameObject;
    TileDetails details = new TileDetails();
    static Color selectColor = Color.red;
    City city;
    List<IRepresentable> units = new List<IRepresentable>();
    int unitIndex = 0;

    public Tile()
    {
    }

    public Tile(Terrain terrain)
    {
        details.Terrain = terrain;
    }

    public GameObject GameObject
    {
        get
        {
            return gameObject;
        }
    }

    public GameObject Instantiate(int x, int y)
    {
        gameObject = GameObject.Instantiate(details.Terrain.prefab, new Vector3(x, 0, y), new Quaternion(0, 0, 0, 0));
        gameObject.name = string.Join("-", new string[] { "tile", x.ToString(), y.ToString() });
        details.Terrain.Color = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
        return gameObject;
    }

    public void Select()
    {
        MeshRenderer mr;
        mr = GameObject.GetComponentInChildren<MeshRenderer>();
        mr.material.color = selectColor;
        //this.DisplayGUI();
        //if (city != null) city.DisplayGUI();
        //if (units.Count > 0)
        //{
        //    units[unitIndex].DisplayGUI();
        //    if (unitIndex++ >= units.Count) unitIndex = 0;
        //}
    }

    public void Unselect()
    {
        MeshRenderer mr;
        mr = GameObject.gameObject.GetComponentInChildren<MeshRenderer>();
        mr.material.color = details.Terrain.Color;
    }

    public Details GetDetails()
    {
        return details;
    }
}
