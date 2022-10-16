using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : Parallax
{
    public override void Start()
    {
    }

    public override void OnCreated()
    {
        base.OnCreated();

        float r, g, b, a;
        r = Random.Range(.98f, 1f);
        g = Random.Range(.98f, 1f);
        b = Random.Range(.98f, 1f);
        a = (float)_order * 0.02f + 1f;

        Color newCol = new Color(r, g, b, a);

        Sr.color = newCol;
    }
}