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
                if (x == 0 && y == 0) tile.AddTestUnit(testUnit);
                tile.Instantiate(x,y).transform.SetParent(mapParent.transform);
                tileMatrix[x][y] = tile;
            }
        }
    }

    public Tile SelectTile(int x, int y)
    {
        if(selectedTile != null)
        {
            selectedTile.Unselect();
        }
        tileMatrix[x][y].Select();
        selectedTile = tileMatrix[x][y];
        return selectedTile;
    }
}
