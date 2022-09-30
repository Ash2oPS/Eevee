using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private Animation _anim;

    public SpriteRenderer sr;

    public void PlayTransition(bool ouverture)
    {
        if (ouverture)
        {
            _anim.Play("TransOpen_A");
            return;
        }

        _anim.Play("TransClose_A");
    }

    public void Destruction()
    {
        Destroy(gameObject);
        Pokemon poke = FindObjectOfType<Pokemon>();

        if (poke == null || poke.CanMove)
            return;

        poke.CanMove = true;
    }
}