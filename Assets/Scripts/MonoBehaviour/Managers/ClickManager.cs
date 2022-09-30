using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private Capstick _capstick;

    public void Click()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _capstick.transform.position = mousePos;

        _capstick.CheckDistanceFromLastPoint();
    }

    public void ReleaseClick()
    {
        _capstick.ReleaseCapstick();
    }
}