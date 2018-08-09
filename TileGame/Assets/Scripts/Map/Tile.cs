﻿using System;
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
        unit.actualTile = this;
        unit.SetMovementCostToNeighboursTiles(this);
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
        unitIndex = 0;
    }
    public void ReleaseUnit(Unit unit)
    {
        units.Remove(unit);
    }

    public void ResetUnitIndex()
    {
        unitIndex = 0;
    }

    public void SwitchToNextUnit()
    {
        unitIndex++;
        if (unitIndex >= units.Count)
            unitIndex = 0;
    }

    public void ChangeColor(Color color)
    {
        MeshRenderer mr;
        mr = GameObject.GetComponentInChildren<MeshRenderer>();
        mr.material.color = color;
    }

    public void ResetColor()
    {
        ChangeColor(terrain.Color);
    }

    public void CreateGUI(GUI gui)
    {
        gui.Display();
    }
}
