using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour, IRepresentable {
    protected UnitType type;

    public int movementRange;
    public int movementPoints;

    public int maxHealthPoints;
    public int healthPoints;

    public List<Tile> path = new List<Tile>();
    public Dictionary<Tile, int> movementCostToNeighboursTiles = new Dictionary<Tile, int>();
    public Tile actualTile;

    GUI gui;

    public GUI Gui
    {
        get
        {
            return gui;
        }
    }

    public UnitType Type
    {
        get
        {
            return type;
        }
    }

    public void CreateGUI(GUI gui)
    {
        this.gui = gui;
        this.gui.Display();
    }

    public void SetMovementCostToNeighboursTiles(Tile tile)
    {
        movementCostToNeighboursTiles = new Dictionary<Tile, int>();
        foreach (Tile t in tile.Neighbours)
        {
            movementCostToNeighboursTiles.Add(t, t.Terrain.cost);
        }
    }

    public void Move()
    {
        while (movementPoints > 0)
        {
            movementPoints -= movementCostToNeighboursTiles[path[0]];
            if(movementPoints < 0)
            {
                movementCostToNeighboursTiles[path[0]] -= movementRange;
                movementPoints = 0;
                break;
            }
            actualTile.ReleaseUnit(this);
            path[0].AddUnit(this);
            actualTile = path[0];
            transform.position = path[0].GameObject.transform.position;
            path.RemoveAt(0);
        }

        
    }
}
