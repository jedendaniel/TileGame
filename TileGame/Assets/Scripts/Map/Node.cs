using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Node
{
    protected List<Node> neighbours = new List<Node>();
    protected int x;
    protected int y;
    public int cost;

    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public List<Node> Neighbours
    {
        get
        {
            return neighbours;
        }
    }

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
    }

    public void AddNeighbour(Node tile)
    {
        neighbours.Add(tile);
    }
    
}
