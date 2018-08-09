using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Soldier : Unit
{
    public int attackDamage;
    public int attackRange;

    public Soldier() : base()
    {
        type = UnitType.SOLDIER;
    }

    public new void CreateGUI(GUI gui)
    {
        base.CreateGUI(gui);
    }

    public new void Move()
    {
        base.Move();
    }

    public void Attack()
    {

    }
}
