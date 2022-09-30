using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHatAccessory", menuName = "Accessory/Hat", order = 0)]
public class Hat : Accessory
{
    public Hat()
    {
        AccessoryType = "Chapeau";
    }
}