using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map{
    
    public int width, height;
    public GameObject mapParent;

    public Terrain[] terrainPrefabs;
    public Dictionary<TileType, Terrain> terrains = new Dictionary<TileType, Terrain>();

    Tile[][] tileMatrix;
    Tile selectedTile;
    
    public Unit testUnit;

    public Tile SelectedTile
    {
        get
        {
            return selectedTile;
        }

        set
        {
            selectedTile = value;
        }
    }

    public Tile GetTile(int x, int y)
    {
        return tileMatrix[x][y];
    }

    public void LoadTerrains()
    {
        foreach (Terrain t in terrainPrefabs)
        {
            terrains.Add(t.type, t);
        }
    }

    public void GenerateMap()
    {
        tileMatrix = new Tile[width][];
        for (int x = 0; x < width; x++)
        {
            tileMatrix[x] = new Tile[height];
            for (int y = 0; y < height; y++)
            {
                Tile tile;
                if (x % 2 == 0) tile = new Tile(terrains[TileType.PLAIN]);
                else tile = new Tile(terrains[TileType.MOUNTAIN]);
                if (x == 0 && y == 0) tile.AddUnit(testUnit);
                tile.Instantiate(x,y).transform.SetParent(mapParent.transform);
                tileMatrix[x][y] = tile;
            }
        }
    }

    public Tile SelectTile(int x, int y)
    {
        if(SelectedTile != null)
        {
            SelectedTile.Unselect();
        }
        tileMatrix[x][y].Select();
        SelectedTile = tileMatrix[x][y];
        return SelectedTile;
    }
}
