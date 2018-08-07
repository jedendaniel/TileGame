using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class City : IRepresentable
{
    GameObject gameObject;
    int size;
    string name;

    public City(string name, GameObject gameObject)
    {
        this.size = 1;
        this.name = name;
        this.gameObject = gameObject;
    }

    public void CreateGUI(GUI gui)
    {
        gui.Display();
    }
}
