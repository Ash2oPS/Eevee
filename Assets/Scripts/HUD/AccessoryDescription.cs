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

    public void DisplayDesciption(Accessory a, bool obtained)
    {
        switch (a.Rating)
        {
            case AccessoryRating.commun:
                _ratingTMP.text = "Commun";
                _ratingTMP.color = new Color(91f / 255f, 91f / 255f, 91f / 255f);
                break;

            case AccessoryRating.peuCommun:
                _ratingTMP.text = "Peu Commun";
                _ratingTMP.color = new Color(158f / 255f, 234f / 255f, 241f / 255f);
                break;

            case AccessoryRating.rare:
                _ratingTMP.text = "Rare !";
                _ratingTMP.color = new Color(250f / 255f, 158f / 255f, 138f / 255f);
                break;

            case AccessoryRating.legendaireOMG:
                _ratingTMP.text = "Légendaire OMG !!";
                _ratingTMP.color = new Color(238f / 255f, 93f / 255f, 218f / 255f);
                break;
        }

        if (!obtained)
        {
            _eeveeSR.sprite = _baseEevee;
            _hatSR.color = new Color(1, 1, 1, 0);
            _earSR.color = new Color(1, 1, 1, 0);
            _tailSR.color = new Color(1, 1, 1, 0);
            _neckSR.color = new Color(1, 1, 1, 0);

            _nameTMP.text = "???";
            _typeTMP.text = a.AccessoryType;
            _descTMP.text = "???";

            return;
        }

        switch (a)
        {
            case Hat h:
                _eeveeSR.sprite = _baseEevee;
                _hatSR.sprite = h.Sprite;
                _hatSR.color = new Color(1, 1, 1, 1);
                _earSR.color = new Color(1, 1, 1, 0);
                _tailSR.color = new Color(1, 1, 1, 0);
                _neckSR.color = new Color(1, 1, 1, 0);
                break;

            case Neck n:
                _eeveeSR.sprite = _baseEevee;
                _hatSR.color = new Color(1, 1, 1, 0);
                _neckSR.sprite = n.Sprite;
                _neckSR.color = new Color(1, 1, 1, 1);
                _tailSR.color = new Color(1, 1, 1, 0);
                _earSR.color = new Color(1, 1, 1, 0);
                break;

            case Tail t:
                _eeveeSR.sprite = _baseEevee;
                _neckSR.color = new Color(1, 1, 1, 0);
                _hatSR.color = new Color(1, 1, 1, 0);
                _tailSR.sprite = t.Sprite;
                _tailSR.color = new Color(1, 1, 1, 1);
                _earSR.color = new Color(1, 1, 1, 0);
                break;

            case Ear e:
                _eeveeSR.sprite = _baseEevee;
                _neckSR.color = new Color(1, 1, 1, 0);
                _hatSR.color = new Color(1, 1, 1, 0);
                _tailSR.color = new Color(1, 1, 1, 0);
                _earSR.sprite = e.Sprite;
                _earSR.color = new Color(1, 1, 1, 1);
                break;

            case Body b:
                _eeveeSR.sprite = b.Sprite;
                _hatSR.color = new Color(1, 1, 1, 0);
                _neckSR.color = new Color(1, 1, 1, 0);
                _tailSR.color = new Color(1, 1, 1, 0);
                _earSR.color = new Color(1, 1, 1, 0);
                break;
        }

        _nameTMP.text = a.AccessoryName;
        _typeTMP.text = a.AccessoryType;
        _descTMP.text = a.Description;
    }
}