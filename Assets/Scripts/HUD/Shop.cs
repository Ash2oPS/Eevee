using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private PlayerManager _pm;
    private Hub_HUD _hud;
    private AccessoryManager _am;
    private bool hasBought;
    public Animation anim;

    public List<Button> OtherButtons;

    [Header("----------Stats")]
    public int GachaCost;

    public int CommunLuck, PeuCommunLuck, RareLuck, LegendaireLuck;

    [Header("----------Prefabs")]
    public RewardShow RewardShow_PF;

    public ChangeUI ChangeUI_PF;

    private void Start()
    {
        _pm = PlayerManager.Instance;
        _hud = FindObjectOfType<Hub_HUD>();

        if (_pm == null)
        {
            return;
        }

        _am = _pm.AM;
    }

    public void GainNugz(int value)
    {
        _pm.AddNuggets(value);
    }

    public void Leave()
    {
        if (hasBought)
        {
            Quit();
        }

        anim.Play("Shop_SaD_A");
    }

    public void SeChanger()
    {
        ChangeUI cui = Instantiate(ChangeUI_PF);
        cui.OnCreated();
        SetButtonsEnabled(false);
    }

    public void SetButtonsEnabled(bool value)
    {
        foreach (Button b in OtherButtons)
        {
            b.enabled = value;
        }
    }

    public void Quit()
    {
        _pm.LoadRoom("Hub");
    }

    public void Gacha()
    {
        if (_pm._nuggets < GachaCost)
        {
            Debug.Log("nope pas assez de nugz");
            return;
        }

        SetButtonsEnabled(false);

        GainNugz(GachaCost * -1);

        Accessory reward = null;
        int nugzValue = 0;

        switch (RandomRating())
        {
            case AccessoryRating.commun:
                reward = _am.CommunAccessories[Random.Range(0, _am.CommunAccessories.Count)];
                nugzValue = 50;
                break;

            case AccessoryRating.peuCommun:
                reward = _am.PeuCommunAccessories[Random.Range(0, _am.PeuCommunAccessories.Count)];
                nugzValue = 75;
                break;

            case AccessoryRating.rare:
                reward = _am.RareAccessories[Random.Range(0, _am.RareAccessories.Count)];
                nugzValue = 90;
                break;

            case AccessoryRating.legendaireOMG:
                reward = _am.LegendaireAccessories[Random.Range(0, _am.LegendaireAccessories.Count)];
                nugzValue = 170;
                break;
        }

        RewardShow rs = Instantiate(RewardShow_PF, Camera.main.transform);
        rs.transform.position = new Vector3(0, 0, 10);
        hasBought = true;

        if (!CheckIfIsOwwned(reward))
        {
            _am.GainReward(reward, true);
            rs.OnCreated(reward);

            return;
        }

        rs.OnCreated(nugzValue);

        _pm.AddNuggets(nugzValue);

        _pm.Save();
    }

    public bool CheckIfIsOwwned(Accessory a)
    {
        if (_am.Items.ObtainedItems[a.ID].IsObtained)
        {
            Debug.Log((_am.Items.ObtainedItems[a.ID].ItemObject as Accessory).AccessoryName + (_am.Items.ObtainedItems[a.ID].ItemObject as Accessory).ID + " était déjà obtenu.");
            return true;
        }

        return false;
    }

    private AccessoryRating? RandomRating()
    {
        if (CommunLuck + PeuCommunLuck + RareLuck + LegendaireLuck != 100)
        {
            Debug.LogError("Gatcha chances n'est pas égal à 100");
            return null;
        }

        int rand = Random.Range(1, 100);

        Debug.Log("Gacha random value = " + rand);

        if (rand <= CommunLuck)
            return AccessoryRating.commun;

        if (rand <= CommunLuck + PeuCommunLuck)
            return AccessoryRating.peuCommun;

        if (rand <= CommunLuck + PeuCommunLuck + RareLuck)
            return AccessoryRating.rare;

        return AccessoryRating.legendaireOMG;
    }
}