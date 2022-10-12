using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeEevee : MonoBehaviour
{
    public Image EeveeImage, HatImage, NeckImage, TailImage, EarImage;
    public AccessoryManager AM;
    private Accessory _newHat, _newNeck, _newTail, _newEar, _newBody;
    private Accessory _oldHat, _oldNeck, _oldTail, _oldEar, _oldBody;

    private void Start()
    {
        AM = FindObjectOfType<AccessoryManager>();
        OldAccessories();
        WearAccessories();
    }

    private void OldAccessories()
    {
        _oldHat = AM.HatAsset;
        _oldNeck = AM.NeckAsset;
        _oldTail = AM.TailAsset;
        _oldEar = AM.EarAsset;
        _oldBody = AM.BodyAsset;

        _newHat = _oldHat;
        _newNeck = _oldNeck;
        _newTail = _oldTail;
        _newEar = _oldEar;
        _newBody = _oldBody;
    }

    public void KeepOldAccessories()
    {
        AM.HatAsset = _oldHat as Hat;
        AM.NeckAsset = _oldNeck as Neck;
        AM.TailAsset = _oldTail as Tail;
        AM.EarAsset = _oldEar as Ear;
        AM.BodyAsset = _oldBody as Body;
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
        if (i == null)
        {
            return;
        }

        if (AM.HatAsset == null)
        {
            i.color = new Color(1, 1, 1, 0);
            return;
        }

        i.color = new Color(1, 1, 1, 1);
        i.sprite = AM.HatAsset.Sprite;
    }

    private void WearNeck(Image i)
    {
        if (i == null)
        {
            return;
        }

        if (AM.NeckAsset == null)
        {
            i.color = new Color(1, 1, 1, 0);
            return;
        }

        i.color = new Color(1, 1, 1, 1);

        i.sprite = AM.NeckAsset.Sprite;
    }

    private void WearEar(Image i)
    {
        if (i == null)
        {
            return;
        }

        if (AM.EarAsset == null)
        {
            i.color = new Color(1, 1, 1, 0);
            return;
        }

        i.color = new Color(1, 1, 1, 1);

        i.sprite = AM.EarAsset.Sprite;
    }

    private void WearTail(Image i)
    {
        if (i == null)
        {
            return;
        }

        if (AM.TailAsset == null)
        {
            i.color = new Color(1, 1, 1, 0);
            return;
        }

        i.color = new Color(1, 1, 1, 1);

        i.sprite = AM.TailAsset.Sprite;
    }

    private void WearBody(Image i)
    {
        if (i == null)
        {
            return;
        }

        if (AM.BodyAsset == null)
        {
            i.sprite = AM.BaseEeveeSprite;
            return;
        }
        i.sprite = AM.BodyAsset.Sprite;
    }
}