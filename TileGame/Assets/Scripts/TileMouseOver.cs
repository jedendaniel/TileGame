using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMouseOver : MonoBehaviour {

	public Color highlightColor;
	Color normalnColor;

	// Use this for initialization
	void Start () {
        normalnColor = gameObject.GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHitInfo;
        if(gameObject.GetComponent<Collider>().Raycast(ray,out raycastHitInfo, Mathf.Infinity))
        {
            gameObject.GetComponent<Renderer>().material.color = highlightColor;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = normalnColor;
        }

    }
}
