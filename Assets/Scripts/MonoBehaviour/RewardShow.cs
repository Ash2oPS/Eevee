using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardShow : MonoBehaviour
{
    public Animation Anim;
    public SpriteRenderer Hat_SR, Neck_SR, Tail_SR, Ear_SR, Eevee_SR;
    public TextMeshPro Item_TMP, Type_TMP, Rating_TMP;
    public string CommunText, PeuCommunText, RareText, LegendaireText;
    public Color CommunColor, PeuCommunColor, RareColor, LegendaireColor;

    public void OnCreated(Accessory accesory)
    {
        Item_TMP.text = accesory.AccessoryName;
        Type_TMP.text = accesory.AccessoryType;

        switch (accesory.Rating)
        {
            case AccessoryRating.commun:
                Rating_TMP.text = CommunText;
                Rating_TMP.color = CommunColor;
                break;

            case AccessoryRating.peuCommun:
                Rating_TMP.text = PeuCommunText;
                Rating_TMP.color = PeuCommunColor;
                break;

            case AccessoryRating.rare:
                Rating_TMP.text = RareText;
                Rating_TMP.color = RareColor;
                break;

            case AccessoryRating.legendaireOMG:
                Rating_TMP.text = LegendaireText;
                Rating_TMP.color = LegendaireColor;
                break;
        }

        switch (accesory)
        {
            case Hat h:
                Hat_SR.sprite = accesory.Sprite;
                break;

            case Neck n:
                Neck_SR.sprite = accesory.Sprite;
                break;

            case Tail t:
                Tail_SR.sprite = accesory.Sprite;
                break;

            case Ear e:
                Ear_SR.sprite = accesory.Sprite;
                break;

            case Body b:
                Eevee_SR.sprite = accesory.Sprite;
                break;
        }

        Anim.Play("RewardShow_Apparition_A");
    }

    public void OnDestruction()
    {
        Anim.Play("RewardShow_Disparition_A");
    }

    public void EndAnim()
    {
        Destroy(gameObject);
    }
}