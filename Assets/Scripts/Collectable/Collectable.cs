using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected virtual void OnCreated()
    {
    }

    public virtual void OnPickedUp(Pokemon poke)
    {
    }

    protected virtual void OnDestroyed()
    {
        Destroy(gameObject);
    }
}