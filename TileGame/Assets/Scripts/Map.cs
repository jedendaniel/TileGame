﻿using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map{
    
    public int width, height;
    public GameObject tilesParent;

    public Terrain plainTerrain;
    public Terrain mountainTerrain;
    public Terrain waterTerrain;

    Tile[][] tileMatrix;
    Tile selectedTile;

    public Map()
    {
    }

    public void GenerateMap()
    {
        tileMatrix = new Tile[width][];
        for (int x = 0; x < width; x++)
        {
            tileMatrix[x] = new Tile[height];
            for (int y = 0; y < height; y++)
            {
                Tile tile = new Tile(plainTerrain);
                tile.Instantiate(x,y).transform.SetParent(tilesParent.transform);
                tileMatrix[x][y] = tile;
            }
        }
    }

    public void SelectTile(int x, int y)
    {
        if(selectedTile != null)
        {
            selectedTile.Unselect();
        }
        tileMatrix[x][y].Select();
        selectedTile = tileMatrix[x][y];
    }
}
