using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AccessorySlotUI : MonoBehaviour
{
    public Accessory AccessoryAsset;
    public ChangeEevee Change;
    public Image i;
    public AccessoryDescription AccDesc;
    public Button b;
    private bool _obtained;

    public void AssignAccessory(Accessory a, ChangeEevee ce, AccessoryDescription ad, bool obtained)
    {
        Change = ce;
        AccDesc = ad;
        AccessoryAsset = a;

        if (!obtained)
            return;

        _obtained = true;
        i.sprite = a.Sprite;
    }

    public void Description()
    {
        AccDesc.DisplayDesciption(AccessoryAsset, _obtained);
        if (_obtained)
            WearIt();
    }

    public void WearIt()
    {
        switch (AccessoryAsset)
        {
            case Hat h:
                Change.AM.HatAsset = h;
                break;

            case Neck n:
                Change.AM.NeckAsset = n;
                break;

            case Tail t:
                Change.AM.TailAsset = t;
                break;

            case Ear e:
                Change.AM.EarAsset = e;
                break;

            case Body b:
                Change.AM.BodyAsset = b;
                break;
        }

        Change.WearAccessories();
    }
}