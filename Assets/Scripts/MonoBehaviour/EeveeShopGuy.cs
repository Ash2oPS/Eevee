using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EeveeShopGuy : MonoBehaviour
{
    public void Quit()
    {
        PlayerManager.Instance.LoadRoom("Hub");
    }
}