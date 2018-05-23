using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    
    public GameObject tilePrefab;
    public int width, height;

    Tile[][] tileMatrix;

    //GameObject selectedTile = null;
    Tile selectedTile;

    Color highlightColor = Color.red;


	// Use this for initialization
	void Start () {
        generateMap();
	}

    void generateMap()
    {
        tileMatrix = new Tile[width][];

        for (int x = 0; x < width; x++)
        {
            tileMatrix[x] = new Tile[height];
            for (int z = 0; z < height; z++)
            {
                tileMatrix[x][z] = new Tile();
                GameObject newTile = (GameObject)Instantiate(tilePrefab, new Vector3(x * 1, 0, z * 1), new Quaternion(0, 0, 0, 0));
                newTile.name = "Tile-" + x + "-" + z;
                newTile.transform.SetParent(this.transform);
                MeshRenderer mr = newTile.GetComponentInChildren<MeshRenderer>();
                //mr.material.color = Color.green;
                tileMatrix[x][z].mNormalColor = mr.material.color;
                tileMatrix[x][z].mTileObject = newTile;
            }
        }
    }

    public void selectTile(GameObject ourHitObject)
    {
        MeshRenderer mr;

        if (selectedTile != null)
        {
            mr = selectedTile.mTileObject.GetComponentInChildren<MeshRenderer>();
            mr.material.color = selectedTile.mNormalColor;
        }
        else
        {
            selectedTile = new Tile();
        }

        selectedTile.mTileObject = ourHitObject;
        mr = selectedTile.mTileObject.GetComponentInChildren<MeshRenderer>();
        selectedTile.mNormalColor = mr.material.color;
        mr.material.color = highlightColor;
    }

    public void changeTile(GameObject gameObject, Tile newTile)
    {
        MeshRenderer mr;

        if (selectedTile != null)
        {
            mr = selectedTile.mTileObject.GetComponentInChildren<MeshRenderer>();
            mr.material.color = selectedTile.mNormalColor;
        }

        string[] nameArray = gameObject.transform.parent.name.Split('-');
        tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].mNormalColor = newTile.mNormalColor;
        Transform origin = tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].mTileObject.transform;
        Object.Destroy(tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].mTileObject);
        tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].mTileObject = Instantiate(newTile.mTileObject, origin.position, origin.rotation, origin.parent);
        tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].mTileObject.name = origin.name;
    }

}
