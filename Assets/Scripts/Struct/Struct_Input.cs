using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct S_Input
{
    public S_KeyCodes Inputs;
    public UnityEvent Event;
    public UnityEvent Release;
}

[Serializable]
public struct S_KeyCodes
{
    public KeyCode Primary, Secondary, Gamepad;
}