using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Soldier : Unit, IRepresentable
{
    public Details GetDetails()
    {
        throw new NotImplementedException();
    }

    public override void Move(Vector2 destination)
    {
        
    }
}
