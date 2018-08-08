using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Tile : Node, IRepresentable
{
    public static Color selectColor = Color.red;
    Terrain terrain = new Terrain();
    GameObject gameObject;
    List<Unit> units = new List<Unit>();
    int unitIndex = 0;

    public Tile(int x, int y) : base(x, y)
    {
        cost = terrain.cost;
    }

    public GameObject GameObject
    {
        get
        {
            return gameObject;
        }
    }

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

    public GameObject Instantiate(int x, int y)
    {
        gameObject = GameObject.Instantiate(terrain.prefab, new Vector3(x, 0, y), Quaternion.identity);
        gameObject.name = string.Join("-", new string[] { "tile", x.ToString(), y.ToString() });
        return gameObject;
    }

    public void AddUnit(Unit unit)
    {
        units.Add(unit);
        unitIndex = units.Count;
    }

    public Unit GetUnit()
    {
        if(units.Count > 0)
        {
            return units[unitIndex];
        }
        return null;
    }

    public void ReleaseUnit()
    {
        units.Remove(units[unitIndex]);
    }

    public void Select()
    {
        MeshRenderer mr;
        mr = GameObject.GetComponentInChildren<MeshRenderer>();
        mr.material.color = selectColor;
        if (units.Count > 0)
        {
            if (unitIndex++ >= units.Count) unitIndex = 0;
        }
    }

    public void Unselect()
    {
        MeshRenderer mr;
        mr = GameObject.gameObject.GetComponentInChildren<MeshRenderer>();
        mr.material.color = terrain.Color;
        unitIndex = units.Count;
    }

    public void CreateGUI(GUI gui)
    {
        gui.Display();
    }
}
