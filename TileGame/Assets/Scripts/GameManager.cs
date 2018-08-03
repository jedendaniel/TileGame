using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameManager : MonoBehaviour {

    
    public Map map;
    
    void Start () {
        map.GenerateMap();
	}
	void Update () {
        if (Input.GetMouseButtonUp(0)) Select();
    }

    void Select()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;
            string[] name = ourHitObject.name.Split('-');
            map.SelectTile(int.Parse(name[1]), int.Parse(name[2]));
        }
    }
}
