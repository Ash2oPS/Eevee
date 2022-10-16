using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Collectable
{
    protected override void OnCreated()
    {
    }

    public override void OnPickedUp(Pokemon poke)
    {
        PlayerManager pm = PlayerManager.Instance;

        if (!pm.IsHoldingBagOfNugs || pm.HeldBagOfNuggets == null)
        {
            return;
        }

        pm.HeldBagOfNuggets.OnEnteringExit();
        pm.Save();
        pm.LoadRoom("Hub");
    }

    protected override void OnDestroyed()
    {
        base.OnDestroyed();
    }
}