using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Window : MonoBehaviour
{
    [Header("----------Parameters")]
    public string Title;

    public string Text;

    [Header("----------References")]
    [SerializeField]
    private TextMeshProUGUI _titleTMP;

    [SerializeField]
    private TextMeshProUGUI _titleShadowTMP, _textTMP;

    [SerializeField]
    private Animation _anim;

    public void CreateWindow(string title, string text)
    {
        Title = title;
        Text = text;

        SetTMPText(_titleTMP, Title);
        SetTMPText(_titleShadowTMP, Title);
        SetTMPText(_textTMP, Text);

        _anim.Play("WindowApparition_A");
    }

    protected void SetTMPText(TextMeshProUGUI tmp, string value)
    {
        tmp.text = value;
    }

    public void DestroyWindow()
    {
        _anim.Play("WindowDisparition_A");
    }

    public void EndOfDisparitionAnimation()
    {
        gameObject.SetActive(false);
    }
}