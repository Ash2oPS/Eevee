using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccessoryDescription : MonoBehaviour
{
    [SerializeField]
    private Sprite _baseEevee;

    [SerializeField]
    private Image _eeveeSR, _neckSR, _hatSR, _tailSR, _earSR;

    [SerializeField]
    private TextMeshProUGUI _nameTMP, _typeTMP, _ratingTMP, _descTMP;

    public void DisplayDesciption(Accessory a)
    {
        switch (a)
        {
            case Hat h:
                _eeveeSR.sprite = _baseEevee;
                _hatSR.sprite = h.Sprite;
                _neckSR.sprite = null;
                _tailSR.sprite = null;
                _earSR.sprite = null;
                break;

            case Neck n:
                _eeveeSR.sprite = _baseEevee;
                _hatSR.sprite = null;
                _neckSR.sprite = n.Sprite;
                _tailSR.sprite = null;
                _earSR.sprite = null;
                break;

            case Tail t:
                _eeveeSR.sprite = _baseEevee;
                _hatSR.sprite = null;
                _neckSR.sprite = null;
                _tailSR.sprite = t.Sprite;
                _earSR.sprite = null;
                break;

            case Ear e:
                _eeveeSR.sprite = _baseEevee;
                _hatSR.sprite = null;
                _neckSR.sprite = null;
                _tailSR.sprite = null;
                _earSR.sprite = e.Sprite;
                break;

            case Body b:
                _eeveeSR.sprite = b.Sprite;
                _hatSR.sprite = null;
                _neckSR.sprite = null;
                _tailSR.sprite = null;
                _earSR.sprite = null;
                break;
        }

        _nameTMP.text = a.AccessoryName;
        _typeTMP.text = a.AccessoryType;
        _descTMP.text = a.Description;

        switch (a.Rating)
        {
            case AccessoryRating.commun:
                _ratingTMP.text = "Commun";
                _ratingTMP.color = new Color(91, 91, 91);
                break;

            case AccessoryRating.peuCommun:
                _ratingTMP.text = "Peu Commun";
                _ratingTMP.color = new Color(158, 234, 241);
                break;

            case AccessoryRating.rare:
                _ratingTMP.text = "Rare !";
                _ratingTMP.color = new Color(250, 158, 138);
                break;

            case AccessoryRating.legendaireOMG:
                _ratingTMP.text = "Légendaire OMG !!";
                _ratingTMP.color = new Color(238, 93, 218);
                break;
        }
    }
}