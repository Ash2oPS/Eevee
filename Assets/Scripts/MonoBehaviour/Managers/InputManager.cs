using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public S_Input Click;

    private void Update()
    {
        if (Key(Click))
        {
            Click.Event.Invoke();
        }
        if (KeyRelease(Click))
        {
            Click.Release.Invoke();
        }
    }

    private bool Key(S_Input input)
    {
        if (Input.GetKey(input.Inputs.Primary))
            return true;
        else if (Input.GetKey(input.Inputs.Secondary))
            return true;
        else if (Input.GetKey(input.Inputs.Gamepad))
            return true;

        return false;
    }

    private bool KeyRelease(S_Input input)
    {
        if (Input.GetKeyUp(input.Inputs.Primary))
            return true;
        else if (Input.GetKeyUp(input.Inputs.Secondary))
            return true;
        else if (Input.GetKeyUp(input.Inputs.Gamepad))
            return true;

        return false;
    }
}