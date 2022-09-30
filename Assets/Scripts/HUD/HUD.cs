using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class HUD : MonoBehaviour
{
    [SerializeField] protected PlayerManager _pm;
    [SerializeField] protected Pokemon _pkmn;
    [SerializeField] protected TextMeshProUGUI _nbOfNuggetsTMP;

    protected void Start()
    {
        MyStart();
    }

    protected virtual void MyStart()
    {
    }

    protected virtual void CheckIfIsOwned()
    {
    }

    public virtual void UpdateNuggets(int value)
    {
    }
}