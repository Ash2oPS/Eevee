using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTailAccessory", menuName = "Accessory/Tail", order = 3)]
public class Tail : Accessory
{
    public Tail()
    {
        AccessoryType = "Queue";
    }
}