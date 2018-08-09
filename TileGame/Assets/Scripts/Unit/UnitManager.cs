using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class UnitManager
{
    public Unit[] unitPrefabs;
    Dictionary<UnitType, Unit> units = new Dictionary<UnitType, Unit>();
    public Unit selectedUnit;
    public List<Unit> allUnits = new List<Unit>();
    List<Unit> unitsWithPath = new List<Unit>();

    public void Load()
    {
        foreach(Unit u in unitPrefabs)
        {
            units.Add(u.Type, u);
        }
    }

    public Unit GetUnitByType(UnitType type)
    {
        return units[type];
    }

    public void UnselectUnit()
    {
        selectedUnit.Gui.Hide();
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
        foreach(Unit u in allUnits)
        {
            u.movementPoints = u.movementRange;
        }
    }
}
