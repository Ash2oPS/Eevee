using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nugget : Collectable
{
    protected override void OnCreated()
    {
    }

    public override void OnPickedUp(Pokemon poke)
    {
        PlayerManager.Instance.AddNuggets(1);
        OnDestroyed();
    }

    protected override void OnDestroyed()
    {
        base.OnDestroyed();
    }
}