using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParentToCam : MonoBehaviour
{
    public bool Centered;

    private void Start()
    {
        Transform cam = FindObjectOfType<Camera>().transform;

        transform.parent = cam;
        if (Centered)
            transform.localPosition = new Vector3(0, 0, 10);
    }
}