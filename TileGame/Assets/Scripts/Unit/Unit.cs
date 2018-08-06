 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour {

    public GameObject unitPrefab;
    public UnitType type;

    public int maxMovementPoints;
    protected int movementPoints;

    public int maxHealthPoints;
    protected int healthPoints;

    public abstract void Move(Vector2 destination);
}
