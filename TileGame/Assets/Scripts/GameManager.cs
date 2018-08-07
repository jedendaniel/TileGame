using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[Serializable]
public class GameManager : MonoBehaviour {

    public Camera mainCamera;
    public Map map;
    public UnitManager unitManager;
    public GUI tileGUI;
    public GUI unitGUI;

    Vector3 rightClickPosition;
    
    void Start () {
        map.LoadTerrains();
        map.GenerateMap();
	}
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            rightClickPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if(rightClickPosition == Input.mousePosition)
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
    }

    void Select()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;
            string[] name = ourHitObject.name.Split('-');
            Tile selectedTile = map.SelectTile(int.Parse(name[1]), int.Parse(name[2]));
            selectedTile.CreateGUI(tileGUI);
            Unit selectedUnit = selectedTile.GetUnit();
            if (selectedUnit != null) selectedTile.CreateGUI(unitGUI);
            else unitGUI.Hide();
        }
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
}
