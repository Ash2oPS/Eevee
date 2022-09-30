using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNeckAccessory", menuName = "Accessory/Neck", order = 1)]
public class Neck : Accessory
{
    public Neck()
    {
        AccessoryType = "Cou";
    }
}