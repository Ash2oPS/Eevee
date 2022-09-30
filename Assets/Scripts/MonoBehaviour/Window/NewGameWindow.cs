using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewGameWindow : Window
{
    [SerializeField]
    private TMP_InputField _inputFieldTMP;

    [SerializeField]
    private TextMeshProUGUI _warningTMP;

    public Canvas can;

    private void Start()
    {
        can.worldCamera = FindObjectOfType<Camera>();
        can.sortingLayerName = "UI";
    }

    public void CheckIfInputFieldEmpty()
    {
        if (_inputFieldTMP.text == "")
        {
            _warningTMP.color = new Vector4(_warningTMP.color.r, _warningTMP.color.g, _warningTMP.color.b, 1);
            return;
        }

        FindObjectOfType<EeveeLauncher>().CreateNewGame(_inputFieldTMP.text);
    }
}