using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Parallax
{
    public void OnCreated()
    {
        float r, g, b, a;
        r = Random.Range(.98f, 1f);
        g = Random.Range(.98f, 1f);
        b = Random.Range(.98f, 1f);
        a = (float)_order * .02f + 1;

        Color newCol = new Vector4(r, g, b, a);

        Sr.color = newCol;
    }
}