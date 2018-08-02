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
                tileMatrix[x][z].normalColor = mr.material.color;
                tileMatrix[x][z].tileObject = newTile;
            }
        }
    }

    public void selectTile(GameObject ourHitObject)
    {
        MeshRenderer mr;

        if (selectedTile != null)
        {
            mr = selectedTile.tileObject.GetComponentInChildren<MeshRenderer>();
            mr.material.color = selectedTile.normalColor;
        }
        else
        {
            selectedTile = new Tile();
        }

        selectedTile.tileObject = ourHitObject;
        mr = selectedTile.tileObject.GetComponentInChildren<MeshRenderer>();
        selectedTile.normalColor = mr.material.color;
        mr.material.color = highlightColor;
    }

    public void changeTile(GameObject gameObject, Tile newTile)
    {
        MeshRenderer mr;

        if (selectedTile != null)
        {
            mr = selectedTile.tileObject.GetComponentInChildren<MeshRenderer>();
            mr.material.color = selectedTile.normalColor;
        }

        string[] nameArray = gameObject.transform.parent.name.Split('-');
        tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].normalColor = newTile.normalColor;
        Transform origin = tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].tileObject.transform;
        Object.Destroy(tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].tileObject);
        tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].tileObject = Instantiate(newTile.tileObject, origin.position, origin.rotation, origin.parent);
        tileMatrix[int.Parse(nameArray[1])][int.Parse(nameArray[2])].tileObject.name = origin.name;
    }

}
