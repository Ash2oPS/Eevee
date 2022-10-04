using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NugzCounter : MonoBehaviour
{
    public TextMeshProUGUI _nugzTMP;
    private PlayerManager _pm;
    private int nugz;

    private void Start()
    {
        _pm = PlayerManager.Instance;
        nugz = _pm._nuggets;

        UpdateNugz(_pm._nuggets);
    }

    public void UpdateNugz(int value)
    {
        _nugzTMP.text = value.ToString();
    }
}