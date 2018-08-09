using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class GameManager : MonoBehaviour {

    public Camera mainCamera;
    public Map map;
    public GUI tileGUI;
    public GUI unitGUI;
    [SerializeField]
    UnitManager unitManager;
    static Color selectColor = Color.red;
    Tile selectedTile;
    Vector3 rightClickedPosition;
    Tile leftClickedTile;


    public Button endTurnButton;

    void Start () {
        unitManager.Load();
        unitManager.Map = map;
        unitManager.SpawnUnit(UnitType.SOLDIER, map.GetTile(0, 0));
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
                SelectTile();
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
                    if(n != selectedTile)
                    {
                        n.ResetColor();
                    }
                }
                if (tile == selectedTile)
                {
                    unitManager.selectedUnit.path.Clear();
                    return;
                }
                unitManager.selectedUnit.path = 
                    map.GeneratePath(selectedTile, tile);
                unitManager.selectedUnit.DrawPath();
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            foreach (Tile n in unitManager.selectedUnit.path)
            {
                if (n != selectedTile)
                {
                    n.ResetColor();
                }
            }
            if (unitManager.selectedUnit.path.Count > 0)
            {
                unitManager.selectedUnit.Move();
                map.ResetTile(selectedTile);
                if (unitManager.selectedUnit.path.Count > 0) unitManager.AddUnitWithPath();
            }
        }
    }

    void SelectTile()
    {
        Tile newTile = GetTileWithRaycast();   
        if (newTile == null) return;
        if(selectedTile != newTile)
        {
            if (selectedTile != null)
            {
                map.ResetTile(selectedTile);
            }
            selectedTile = newTile;
            selectedTile.ChangeColor(selectColor);
            selectedTile.CreateGUI(tileGUI);
        }
        else
        {
            selectedTile.SwitchToNextUnit();
        }
        if (unitManager.selectedUnit != null)
        {
            foreach (Tile t in unitManager.selectedUnit.path)
            {
                t.ResetColor();
            }
        }
        unitManager.selectedUnit = selectedTile.GetUnit();
        if (unitManager.selectedUnit != null)
        {
            unitManager.selectedUnit.CreateGUI(unitGUI);
            unitManager.selectedUnit.DrawPath();
        }
        else unitGUI.Hide();
    }

    Tile GetTileWithRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;
            if(ourHitObject != null)
            {
                string[] name = ourHitObject.name.Split('-');
                Tile selectedTile = map.GetTile(int.Parse(name[1]), int.Parse(name[2]));
                return selectedTile;
            }
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
        if (selectedTile != null)
        {
            if (unitManager.selectedUnit != null)
            {
                foreach (Tile t in unitManager.selectedUnit.path)
                {
                    t.ResetColor();
                }
            }
            map.ResetTile(selectedTile);
            selectedTile = null;
        }
        unitManager.MoveAutomatically();
        unitManager.Restore();
    }
}
