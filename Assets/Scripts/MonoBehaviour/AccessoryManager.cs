using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region AccessoryManager

public class AccessoryManager : MonoBehaviour
{
    [Header("----------Assets")]
    public Hat HatAsset;

    public Neck NeckAsset;
    public Ear EarAsset;
    public Tail TailAsset;
    public Body BodyAsset;

    public Sprite BaseEeveeSprite;

    public AllObtainedItems Items;
    public List<Accessory> CommunAccessories, PeuCommunAccessories, RareAccessories, LegendaireAccessories;

    private List<int> _itemIDs;

    public List<int> ItemIDs
    { get { return _itemIDs; } }

    [Header("----------IO")]
    public AllItemsGetter AllItemsGetter;

    private void Start()
    {
        CommunAccessories = new List<Accessory>();
        PeuCommunAccessories = new List<Accessory>();
        RareAccessories = new List<Accessory>();
        LegendaireAccessories = new List<Accessory>();

        CopyAllItems();

        _itemIDs = new List<int>();
    }

    private void CopyAllItems()
    {
        foreach (ObtainedItem item in AllItemsGetter.Items.ObtainedItems)
        {
            Items.ObtainedItems.Add(new ObtainedItem(item.ItemObject, false));

            switch ((item.ItemObject as Accessory).Rating)
            {
                case AccessoryRating.commun:
                    CommunAccessories.Add(item.ItemObject as Accessory);
                    break;

                case AccessoryRating.peuCommun:
                    PeuCommunAccessories.Add(item.ItemObject as Accessory);
                    break;

                case AccessoryRating.rare:
                    RareAccessories.Add(item.ItemObject as Accessory);
                    break;

                case AccessoryRating.legendaireOMG:
                    LegendaireAccessories.Add(item.ItemObject as Accessory);
                    break;
            }
        }
    }

    public void WearAccessories(SpriteRenderer hatSR, SpriteRenderer neckSR, SpriteRenderer earSR, SpriteRenderer tailSR, SpriteRenderer bodySR)
    {
        WearHat(hatSR);
        WearNeck(neckSR);
        WearEar(earSR);
        WearTail(tailSR);
        WearBody(bodySR);
    }

    private void WearHat(SpriteRenderer sr)
    {
        if (HatAsset == null || sr == null)
        {
            return;
        }

        sr.sprite = HatAsset.Sprite;
    }

    private void WearNeck(SpriteRenderer sr)
    {
        if (NeckAsset == null || sr == null)
        {
            return;
        }

        sr.sprite = NeckAsset.Sprite;
    }

    private void WearEar(SpriteRenderer sr)
    {
        if (EarAsset == null || sr == null)
        {
            return;
        }

        sr.sprite = EarAsset.Sprite;
    }

    private void WearTail(SpriteRenderer sr)
    {
        if (TailAsset == null || sr == null)
        {
            return;
        }

        sr.sprite = TailAsset.Sprite;
    }

    private void WearBody(SpriteRenderer sr)
    {
        if (sr == null)
        {
            return;
        }

        if (BodyAsset == null)
        {
            sr.sprite = BaseEeveeSprite;
            return;
        }
        sr.sprite = BodyAsset.Sprite;
    }

    public void GainReward(Accessory a, bool save)
    {
        if (CheckIfNotAlreadyInList(a.ID))
        {
            return;
        }

        _itemIDs.Add(a.ID);
        ObtainedItem newObtained = new ObtainedItem(Items.ObtainedItems[a.ID].ItemObject, true);

        Items.ObtainedItems[a.ID] = newObtained;

        if (save)
            PlayerManager.Instance.Save();
    }

    private bool CheckIfNotAlreadyInList(int value)                 //return true si l'id est déjà dans la list
    {
        if (_itemIDs.Count != 0)
        {
            foreach (int i in _itemIDs)
            {
                if (i == value)
                {
                    return true;
                }

                return false;
            }
        }

        return false;
    }
}

#endregion AccessoryManager