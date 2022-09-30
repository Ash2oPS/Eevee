using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagOfNuggets : Collectable
{
    public int BaseNuggetValue = 50, CurrentValue, MinNuggetValue = 15;
    public float LoseValueRate = 1f;
    private Coroutine _currentCoroutine;
    public TextMeshPro ValueTMP;
    public PlayerManager pm;
    public Color startCol, endCol, deadCol;
    public bool DeadBag;
    public GameObject thingToDisable, thingToDisable2;
    public FloatingAnimation floatAnim;
    public Animation Anim;

    protected override void OnCreated()
    {
    }

    public override void OnPickedUp(Pokemon poke)
    {
        pm = PlayerManager.Instance;

        if (!pm.IsHoldingBagOfNugs)
        {
            thingToDisable.SetActive(false);
            thingToDisable2.SetActive(false);
            floatAnim.StopCoroutine(floatAnim.FlotationCoroutine);

            transform.parent = poke.transform;                      //est enfant du pokémon
            transform.localPosition = new Vector3(0, 1.5f, 0);      //est un peu plus haut que le pokémon

            pm.IsHoldingBagOfNugs = true;                           //joueur tient un bag of nugz
            pm.HeldBagOfNuggets = this;                             //le joueur tient CE bag of nugz

            CurrentValue = BaseNuggetValue;                         //initalise la value à celle de base
            UpdateText();                                           //affiche la valeur

            _currentCoroutine = StartCoroutine(LosingValue());      //commence la coroutine de perte de valeur
        }
    }

    protected override void OnDestroyed()
    {
        base.OnDestroyed();
    }

    private IEnumerator LosingValue()
    {
        while (true)
        {
            yield return new WaitForSeconds(LoseValueRate);
            LoseValue();
        }
    }

    private void LoseValue()
    {
        CurrentValue--;
        UpdateText();
        Anim.Play("BagOfNugz_Loss_A");
        if (CurrentValue <= MinNuggetValue)
        {
            StopCoroutine(_currentCoroutine);
            DeadBag = true;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        ValueTMP.text = CurrentValue.ToString();

        if (!DeadBag)
        {
            float result = (float)CurrentValue / (float)BaseNuggetValue;
            ValueTMP.color = Color.Lerp(endCol, startCol, result);
            return;
        }

        ValueTMP.color = deadCol;
    }

    public void OnEnteringExit()
    {
        pm.AddNuggets(CurrentValue);
        StopCoroutine(_currentCoroutine);
        pm.IsHoldingBagOfNugs = false;
        pm.HeldBagOfNuggets = null;
        OnDestroyed();
    }
}