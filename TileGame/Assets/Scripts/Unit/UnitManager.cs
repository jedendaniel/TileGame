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

    public void MoveUnits()
    {

    }
}
