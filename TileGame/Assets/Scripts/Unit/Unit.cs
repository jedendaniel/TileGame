 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour {
    public UnitType type;

    public int movementRange;
    public int movementPoints;

    public int maxHealthPoints;
    public int healthPoints;

    public abstract void Move(Tile destination);
}
