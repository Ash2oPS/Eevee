using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBodyAccessory", menuName = "Accessory/Body", order = 4)]
public class Body : Accessory
{
    public Body()
    {
        AccessoryType = "Corps";
    }
}