using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitManager
{
    public Unit[] unitPrefabs;
    Dictionary<UnitType, Unit> units = new Dictionary<UnitType, Unit>();
    [HideInInspector]
    public Unit selectedUnit;
    [HideInInspector]
    public List<Unit> inGameUnits = new List<Unit>();
    List<Unit> unitsWithPath = new List<Unit>();
    Map map;

    public Map Map
    {
        set
        {
            map = value;
        }
    }

    public void Load()
    {
        foreach(Unit u in unitPrefabs)
        {
            units.Add(u.Type, u);
            u.Init();
        }
    }

    public Unit GetUnitByType(UnitType type)
    {
        return units[type];
    }

    public void SpawnUnit(UnitType type, Tile tile)
    {
        Unit newUnit = GameObject.Instantiate(units[type], tile.GameObject.transform.position, Quaternion.identity);
        tile.AddUnit(newUnit);
        inGameUnits.Add(newUnit);
    }

    public void AddUnitWithPath()
    {
        unitsWithPath.Add(selectedUnit);
    }

    public void MoveAutomatically()
    {
        List<Unit> unitsWithEndedPath = new List<Unit>();
        foreach(Unit u in unitsWithPath)
        {
            if (u.path.Count == 0) unitsWithEndedPath.Add(u);
            else u.Move();
        }
        foreach(Unit u in unitsWithEndedPath)
        {
            unitsWithPath.Remove(u);
        }
    }

    public void Restore()
    {
        foreach(Unit u in inGameUnits)
        {
            u.movementPoints = u.movementRange;
        }
    }
}
