using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClassicGameHUD : HUD
{
    protected override void MyStart()
    {
        _pm = _pkmn.PlayerManager;
        CheckIfIsOwned();
        UpdateNuggets(_pm._nuggets);
    }

    public override void UpdateNuggets(int value)
    {
        _nbOfNuggetsTMP.text = value.ToString();
    }
}