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

    public void Move(Tile destinationTile)
    {
        destinationTile.AddUnit(this);
        transform.position = destinationTile.GameObject.transform.position;
    }

    public void TakeStep()
    {

    }
}
