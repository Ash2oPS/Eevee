using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEarAccessory", menuName = "Accessory/Ear", order = 2)]
public class Ear : Accessory
{
    public Ear()
    {
        AccessoryType = "Oreille";
    }
}