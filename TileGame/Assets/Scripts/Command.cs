using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

public abstract class Command
{
    public Command() { }
    public abstract void execute(GameManager gameManager);
}

public class MouseButtonDownCommand : Command
{
    public MouseButtonDownCommand() : base()
    {
    }
    public override void execute(GameManager gameManager)
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
                    if (gameManager.EditorMode)
                    {
                        gameManager.map.changeTile(ourHitObject, gameManager.editorSelectedTile);
                    }
                    else
                    {
                        gameManager.map.selectTile(ourHitObject);
                    }
                    
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
    public override void execute(GameManager gameManager)
    {
        Debug.Log("OoooooOoo");
    }
}


public class Button1Command : Command
{
    public Button1Command() : base() { }
    public override void execute(GameManager gameManager)
    {
        gameManager.editorSelectedTile = gameManager.mMountain;
        Debug.Log("Mountain selected");
    }
}


public class Button2Command : Command
{
    public Button2Command() : base() { }
    public override void execute(GameManager gameManager)
    {
        gameManager.editorSelectedTile = gameManager.mPlain;
        Debug.Log("Plain selected");
    }
}

public class Button3Command : Command
{
    public Button3Command() : base() { }
    public override void execute(GameManager gameManager)
    {
        gameManager.editorSelectedTile = gameManager.mWater;
        Debug.Log("Water selected");
    }
}

public class Button4Command : Command
{
    public Button4Command() : base() { }
    public override void execute(GameManager gameManager)
    {
        
    }
}

public class ButtonEditorModeSwitch : Command
{
    public ButtonEditorModeSwitch() : base() { }
    public override void execute(GameManager gameManager)
    {
        if (gameManager.EditorMode)
        {
            gameManager.EditorMode = false;
            Debug.Log("Editor mode off");
        }
        else
        {
            gameManager.EditorMode = true;
            Debug.Log("Editor mode on");
        }
    }
}

