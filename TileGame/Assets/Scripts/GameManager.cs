using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameManager : MonoBehaviour {

    public Camera mainCamera;
    public Map map;
    public UnitManager unitManager;
    public GUI tileGUI;
    public GUI unitGUI;

    Vector3 rightClickedPosition;
    Tile leftClickedTile;

    public Button endTurnButton;

    void Start () {
        unitManager.Load();
        map.GetTile(0, 0).AddUnit(unitManager.GetUnitByType(UnitType.SOLDIER));
        endTurnButton.onClick.AddListener(EndTurn);
	}

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            rightClickedPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(rightClickedPosition == Input.mousePosition)
                Select();
        }
        if (Input.GetMouseButton(0))
        {
            MoveCameraHorizontally();
        }
        if(Input.GetAxis("Mouse Scroll") != 0)
        {
            MoveCameraVertically();
        }
        if (Input.GetMouseButton(1))
        {
            if (unitManager.selectedUnit != null)
            {
                Tile tile = GetTileWithRaycast();
                if (tile == leftClickedTile || tile == null) return;
                leftClickedTile = tile;
                foreach (Tile n in unitManager.selectedUnit.path)
                {
                    if(n != map.SelectedTile)
                    {
                        MeshRenderer mr;
                        mr = n.GameObject.GetComponentInChildren<MeshRenderer>();
                        mr.material.color = n.Terrain.Color;
                    }
                }
                if (tile == map.SelectedTile)
                {
                    unitManager.selectedUnit.path.Clear();
                    return;
                }
                unitManager.selectedUnit.path = 
                    map.GeneratePath(map.SelectedTile, tile);
                foreach(Tile n in unitManager.selectedUnit.path)
                {
                    if (n != map.SelectedTile)
                    {
                        MeshRenderer mr;
                        mr = n.GameObject.GetComponentInChildren<MeshRenderer>();
                        mr.material.color = Color.white;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            foreach (Tile n in unitManager.selectedUnit.path)
            {
                if (n != map.SelectedTile)
                {
                    MeshRenderer mr;
                    mr = n.GameObject.GetComponentInChildren<MeshRenderer>();
                    mr.material.color = n.Terrain.Color;
                }
            }
        }
    }

    void Select()
    {
        Tile selectedTile = GetTileWithRaycast();
        if (selectedTile == null) return;
        map.SelectTile(selectedTile);
        selectedTile.CreateGUI(tileGUI);
        unitManager.selectedUnit = selectedTile.GetUnit();
        if (unitManager.selectedUnit != null) unitManager.selectedUnit.CreateGUI(unitGUI);
        else unitGUI.Hide();
    }

    Tile GetTileWithRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;
            string[] name = ourHitObject.name.Split('-');
            Tile selectedTile = map.GetTile(int.Parse(name[1]), int.Parse(name[2]));
            return selectedTile;
        }
        return null;
    }

    void MoveCameraHorizontally()
    {
        mainCamera.transform.position -= new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
    }

    void MoveCameraVertically()
    {
        mainCamera.transform.position -= Vector3.up * Input.GetAxis("Mouse Scroll");
        if (mainCamera.transform.position.y > 10)
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 10, mainCamera.transform.position.z);
        if (mainCamera.transform.position.y < 5)
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, 5, mainCamera.transform.position.z);
    }

    void EndTurn()
    {

    }
}
