using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameManager : MonoBehaviour {

    public Map map;
    private InputHandler inputHandler;
    private Command command;

    // Use this for initialization
    void Start () {
        map = (Map)Instantiate(map);
        inputHandler = new InputHandler();
	}
	// Update is called once per frame
	void Update () {
        command = inputHandler.GetInput();
        if (command != null)
        {
            command.Execute(this);
        }
    }
}
