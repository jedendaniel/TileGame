using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileGUI : GUI {

    public Text terrainText;
    public Button upgradeButton;
    Tile selectedTile;

	void Start () {
        upgradeButton.onClick.AddListener(UpgradeTile);
	}
	
    public void Select(Tile tile)
    {
        selectedTile = tile;
    }

    public override void Display()
    {
        gameObject.SetActive(true);
        TileDetails tileDetails = (TileDetails)selectedTile.GetDetails();
        terrainText.text = tileDetails.Terrain.type.ToString();
    }

    void UpgradeTile()
    {
        Debug.Log("tile upgraded");
    }
}
