using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CityDetails : Details
{
    int size;
    string name;

    public int Size
    {
        get
        {
            return size;
        }

        set
        {
            size = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }
}
