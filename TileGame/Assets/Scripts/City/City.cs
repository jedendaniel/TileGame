using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class City : IRepresentable
{
    GameObject gameObject;
    CityDetails details = new CityDetails();

    public City(string name, GameObject gameObject)
    {
        details.Size = 1;
        details.Name = name;
        this.gameObject = gameObject;
    }

    public Details GetDetails()
    {
        return details;
    }
}
