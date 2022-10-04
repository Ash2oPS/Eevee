using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEevee : MonoBehaviour
{
    public Image EeveeImage, HatImage, NeckImage, TailImage, EarImage;
    private AccessoryManager _am;

    private void Start()
    {
        _am = FindObjectOfType<AccessoryManager>();
    }

    public void WearAccessories()
    {
        WearHat(HatImage);
        WearNeck(NeckImage);
        WearEar(EarImage);
        WearTail(TailImage);
        WearBody(EeveeImage);
    }

    private void WearHat(Image i)
    {
        if (_am.HatAsset == null || i == null)
        {
            return;
        }

        i.sprite = _am.HatAsset.Sprite;
    }

    private void WearNeck(Image i)
    {
        if (_am.NeckAsset == null || i == null)
        {
            return;
        }

        i.sprite = _am.NeckAsset.Sprite;
    }

    private void WearEar(Image i)
    {
        if (_am.EarAsset == null || i == null)
        {
            return;
        }

        i.sprite = _am.EarAsset.Sprite;
    }

    private void WearTail(Image i)
    {
        if (_am.TailAsset == null || i == null)
        {
            return;
        }

        i.sprite = _am.TailAsset.Sprite;
    }

    private void WearBody(Image i)
    {
        if (i == null)
        {
            return;
        }

        if (_am.BodyAsset == null)
        {
            i.sprite = _am.BaseEeveeSprite;
        }
        i.sprite = _am.BodyAsset.Sprite;
    }
}