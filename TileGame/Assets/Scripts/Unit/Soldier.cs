using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Soldier : Unit, IRepresentable
{
    public int attackDamage;
    public int attackRange;

    public void Start()
    {
        
    }

    public void CreateGUI(GUI gui)
    {
        gui.Display();
    }

    public override void Move(Tile destination)
    {

    }

    public void Attack()
    {

    }
}
