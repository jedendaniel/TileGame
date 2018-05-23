using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameManager : MonoBehaviour {

    public Map map;
    public InputHandler inputHandler;
    private Command command;
    public bool EditorMode { get; set; }

    public GameObject mMountainPrefab;
    public Tile mMountain;
    public GameObject mPlainPrefab;
    public Tile mPlain;
    public GameObject mWaterPrefab;
    public Tile mWater;
    public Tile editorSelectedTile;

    // Use this for initialization
    void Start () {
        TileTypesSetUp();
        map = (Map)Instantiate(map);
        inputHandler = new InputHandler();
	}
	// Update is called once per frame
	void Update () {
        command = inputHandler.getInput();
        if (command != null)
        {
            command.execute(this);
        }
    }

    void TileTypesSetUp()
    {
        mMountain = new Tile();
        mMountain.mTileObject = mMountainPrefab;
        mMountain.mNormalColor = Color.gray;
        mPlain = new Tile();
        mPlain.mTileObject = mPlainPrefab;
        mPlain.mNormalColor = Color.green;
        mWater = new Tile();
        mWater.mTileObject = mWaterPrefab;
        mWater.mNormalColor = Color.yellow;
    }
}
