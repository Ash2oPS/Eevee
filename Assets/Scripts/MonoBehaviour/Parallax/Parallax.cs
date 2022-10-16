using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public SpriteRenderer Sr;
    protected Pokemon eevee;
    protected Vector3 _anchorPos, _eeveeAnchorPos;
    protected int _order;

    public virtual void Start()
    {
        eevee = FindObjectOfType<Pokemon>();
        _anchorPos = transform.localPosition;
        _eeveeAnchorPos = eevee.transform.position;
        _order = Sr.sortingOrder;
    }

    public virtual void OnCreated()
    {
        eevee = FindObjectOfType<Pokemon>();
        _anchorPos = transform.localPosition;
        _eeveeAnchorPos = eevee.transform.position;
        _order = Sr.sortingOrder;
        Debug.Log(Sr.sortingOrder + " a");
    }

    public void Update()
    {
        float x, y;
        x = (_eeveeAnchorPos.x - eevee.transform.position.x * ((float)_order * .02f + 1)) / 2;
        y = (_eeveeAnchorPos.y - eevee.transform.position.y * ((float)_order * .02f + 1)) / 2;
        transform.localPosition = new Vector3(_anchorPos.x + x, _anchorPos.y + y, _anchorPos.z);
    }
}