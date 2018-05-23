using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{

    private MouseButtonDownCommand mouseButtonDown;
    private Command buttonO;
    private Command button1;
    private Command button2;
    private Command button3;
    private Command button4;
    private Command buttonEditorModeSwitch;

    public InputHandler()
    {
        mouseButtonDown = new MouseButtonDownCommand();
        buttonO = new ButtonOCommand();
        button1 = new Button1Command();
        button2 = new Button2Command();
        button3 = new Button3Command();
        button4 = new Button4Command();
        buttonEditorModeSwitch = new ButtonEditorModeSwitch();
    }

    public Command getInput()
    {
        if (Input.anyKey)
        {
            if (Input.GetMouseButtonDown(0)) return mouseButtonDown;
            if (Input.GetKeyDown("o")) return buttonO;
            if (Input.GetKeyDown("1")) return button1;
            if (Input.GetKeyDown("2")) return button2;
            if (Input.GetKeyDown("3")) return button3;
            if (Input.GetKeyDown("4")) return button4;
            if (Input.GetKeyDown("e")) return buttonEditorModeSwitch;
        }
        return null;
    }
}
