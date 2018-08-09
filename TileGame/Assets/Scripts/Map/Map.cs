using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    public int width, height;
    public Terrain[] terrainPrefabs;
    public Dictionary<TileType, Terrain> terrains = new Dictionary<TileType, Terrain>();
    
    public Tile[,] tiles;
    
    private void Start()
    {
        LoadTerrains();
        GenerateMap();
    }

    public Tile GetTile(int x, int y)
    {
        return tiles[x,y];
    }

    public void ResetTile(Tile tile)
    {
        tile.ResetColor();
        tile.ResetUnitIndex();
    }

    public void LoadTerrains()
    {
        foreach (Terrain t in terrainPrefabs)
        {
            terrains.Add(t.type, t);
            t.Color = t.prefab.GetComponentInChildren<Renderer>().sharedMaterial.color;
        }
    }

    public void GenerateMap()
    {
        tiles = new Tile[width,height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile tile = new Tile(x, y);
                tiles[x, y] = tile;
                tiles[x, y].Terrain = terrains[TileType.PLAIN];
            }
        }
        SetMapPattern();
        SetTestData();
        GenerateVisualMap();
        GenerateGraph();
    }

    public void GenerateVisualMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y].Instantiate(x, y).transform.SetParent(transform);
            }
        }
    }

    void SetMapPattern()
    {
        tiles[1, 1].Terrain = terrains[TileType.MOUNTAIN];
        tiles[2, 1].Terrain = terrains[TileType.MOUNTAIN];
        tiles[3, 1].Terrain = terrains[TileType.MOUNTAIN];
        tiles[4, 1].Terrain = terrains[TileType.MOUNTAIN];
        tiles[5, 1].Terrain = terrains[TileType.MOUNTAIN];
        tiles[1, 2].Terrain = terrains[TileType.MOUNTAIN];
        tiles[1, 3].Terrain = terrains[TileType.MOUNTAIN];
        tiles[5, 2].Terrain = terrains[TileType.MOUNTAIN];
        tiles[5, 3].Terrain = terrains[TileType.MOUNTAIN];
    }

    void SetTestData()
    {
    }

    void GenerateGraph()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tiles[x, y].cost = tiles[x, y].Terrain.cost;

                if (x > 0)
                    tiles[x, y].AddNeighbour(tiles[x -1, y]);
                if (x < width - 1)
                    tiles[x, y].AddNeighbour(tiles[x + 1,y]);
                if (y > 0)
                    tiles[x, y].AddNeighbour(tiles[x,y - 1]);
                if (y < height - 1)
                    tiles[x, y].AddNeighbour(tiles[x,y + 1]);

                if (x > 0 && y > 0)
                    tiles[x, y].AddNeighbour(tiles[x - 1, y - 1]);
                if (x > 0 && y < height - 1)
                    tiles[x, y].AddNeighbour(tiles[x - 1, y + 1]);
                if (x < width - 1 && y > 0)
                    tiles[x, y].AddNeighbour(tiles[x + 1, y - 1]);
                if (x < width - 1 && y < height - 1)
                    tiles[x, y].AddNeighbour(tiles[x + 1, y + 1]);
            }
        }
    }

    public List<Tile> GeneratePath(Tile source, Tile target)
    {
        Dictionary<Tile, int> dist = new Dictionary<Tile, int>();
        Dictionary<Tile, Tile> prev = new Dictionary<Tile, Tile>();
        List<Tile> unvisited = new List<Tile>();
        
        dist[source] = 0;
        prev[source] = null;
        
        foreach (Tile v in tiles)
        {
            if (v != source)
            {
                dist[v] = int.MaxValue;
                prev[v] = null;
            }
            unvisited.Add(v);
        }

        while (unvisited.Count > 0)
        {
            Tile u = null;
            foreach (Tile possibleU in unvisited)
            {
                if (u == null || dist[possibleU] < dist[u])
                {
                    u = possibleU;
                }
            }
            if (u == target)
            {
                break;
            }
            unvisited.Remove(u);
            foreach (Tile v in u.Neighbours)
            {
                int alt = dist[u] + u.cost;
                if (alt < dist[v])
                {
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }

        if (prev[target] == null)
        {
            return null;
        }

        List<Tile> currentPath = new List<Tile>();
        Tile curr = target;
        while (curr != null)
        {
            currentPath.Add(curr);
            curr = prev[curr];
        }
        currentPath.Reverse();
        currentPath.RemoveAt(0);
        return currentPath;
    }
}
