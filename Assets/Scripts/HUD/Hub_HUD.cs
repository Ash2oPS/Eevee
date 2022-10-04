using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hub_HUD : MonoBehaviour
{
    private PlayerManager _pm;
    private int nugz;

    [Header("----------References")]
    [SerializeField]
    private TextMeshProUGUI _nugzTMP;

    private void Start()
    {
        _pm = PlayerManager.Instance;
    }

    public void GoTo(string scene)
    {
        _pm.LoadRoom(scene);
    }
}