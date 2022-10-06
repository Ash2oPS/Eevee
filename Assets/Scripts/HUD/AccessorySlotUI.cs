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
    public UnityEvent OnHover;

    private void Start()
    {
        OnHover.AddListener(Description);
    }

    public void AssignAccessory(Accessory a, ChangeEevee ce, AccessoryDescription ad)
    {
        AccessoryAsset = a;
        Change = ce;
        i.sprite = a.Sprite;
        AccDesc = ad;

        //TO DO :  au moment de créer tous les slots, on assigne le changeEevee (l'évoli de preview qui montrer les accessoires qui vont etre portés,
        // l'accessory description (les textes et images de decription d'accessoire) et l'accessory asset
    }

    
    private void Description()
    {
        Debug.Log("oui");
    }

    public void WearIt()
    {
    }
}