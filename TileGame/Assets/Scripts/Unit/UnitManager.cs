﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class UnitManager
{
    public Unit[] unitPrefabs;
    Dictionary<UnitType, Unit> units = new Dictionary<UnitType, Unit>();

    public void Load()
    {
        foreach(Unit u in unitPrefabs)
        {
            units.Add(u.type, u);
        }
    }
}