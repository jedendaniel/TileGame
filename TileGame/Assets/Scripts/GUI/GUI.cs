using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class GUI : MonoBehaviour
{
    public abstract void Display();

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
