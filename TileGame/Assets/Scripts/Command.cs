using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

public abstract class Command
{
    public Command() { }
    public abstract void Execute();
}

public class MouseButtonDownCommand : Command
{
    GameManager gameManager;

    public MouseButtonDownCommand(GameManager gameManager) : base()
    {
        this.gameManager = gameManager;
    }
    public override void Execute()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;
            String[] ourHitName = ourHitObject.transform.parent.name.Split('-');

            switch (ourHitName[0])
            {
                case "Tile":
                    //gameManager.map.SelectTile(ourHitObject);
                    break;
            }
        }
        else
        {
            Debug.Log("Raycast hit nothing");
        }
    }
}

public class ButtonOCommand : Command
{
    public ButtonOCommand() : base() { }
    public override void Execute()
    {
        Debug.Log("OoooooOoo");
    }
}

public class Button4Command : Command
{
    public Button4Command() : base() { }
    public override void Execute()
    {
        
    }
}

