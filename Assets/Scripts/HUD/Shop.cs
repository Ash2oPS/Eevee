using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private PlayerManager _pm;
    private Hub_HUD _hud;
    private AccessoryManager _am;
    private bool hasBought;
    public Animation anim;

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

    /*public void WearIt(Accessory a)
    {
        switch (a)
        {
            case Hat h:
                _am.HatAsset = h;
                break;

            case Neck n:
                _am.NeckAsset = n;
                break;
        }
    }*/

    public void SeChanger()
    {
        ChangeUI cui = Instantiate(ChangeUI_PF);
        cui.OnCreated();
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

        GainNugz(GachaCost * -1);

        Accessory reward = null;

        switch (RandomRating())
        {
            case AccessoryRating.commun:
                reward = _am.CommunAccessories[Random.Range(0, _am.CommunAccessories.Count)];
                break;

            case AccessoryRating.peuCommun:
                reward = _am.PeuCommunAccessories[Random.Range(0, _am.PeuCommunAccessories.Count)];
                break;

            case AccessoryRating.rare:
                reward = _am.RareAccessories[Random.Range(0, _am.RareAccessories.Count)];
                break;

            case AccessoryRating.legendaireOMG:
                reward = _am.LegendaireAccessories[Random.Range(0, _am.LegendaireAccessories.Count)];
                break;
        }

        _am.GainReward(reward, true);

        Debug.Log(reward.AccessoryName + " " + reward.ID);
        Debug.Log(((_am.Items.ObtainedItems[reward.ID].ItemObject) as Accessory).AccessoryName + " " + _am.Items.ObtainedItems[reward.ID].IsObtained);

        RewardShow rs = Instantiate(RewardShow_PF, Camera.main.transform);
        rs.transform.position = new Vector3(0, 0, 10);
        rs.OnCreated(reward);

        hasBought = true;
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