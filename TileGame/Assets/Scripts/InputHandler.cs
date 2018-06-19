using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{

    private MouseButtonDownCommand mouseButtonDown;
    private Command buttonO;
    private Command button4;

    public InputHandler()
    {
        mouseButtonDown = new MouseButtonDownCommand();
        buttonO = new ButtonOCommand();
        button4 = new Button4Command();
    }

    public Command getInput()
    {
        if (Input.anyKey)
        {
            if (Input.GetMouseButtonDown(0)) return mouseButtonDown;
            if (Input.GetKeyDown("o")) return buttonO;
            if (Input.GetKeyDown("4")) return button4;
        }
        return null;
    }
}
