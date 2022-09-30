using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private PlayerManager _pm;
    private Hub_HUD _hud;
    private AccessoryManager _am;

    [Header("----------Stats")]
    public int GachaCost;

    [Header("----------Prefabs")]
    public RewardShow RewardShow_PF;

    private void Start()
    {
        _pm = PlayerManager.Instance;
        _hud = FindObjectOfType<Hub_HUD>();
        _am = _pm.AM;
    }

    public void GainNugz(int value)
    {
        _pm.AddNuggets(value);
        _hud.UpdateNugz();
    }

    public void Gacha()
    {
        if (_pm._nuggets < GachaCost)
        {
            Debug.Log("nope pas assez de nugz");
            return;
        }

        GainNugz(GachaCost * -1);

        Accessory reward = _am.Items.ObtainedItems[Random.Range(0, _am.Items.ObtainedItems.Count)].ItemObject as Accessory;

        _am.GainReward(reward, true);

        Debug.Log(reward.AccessoryName + " " + reward.ID);
        Debug.Log(((_am.Items.ObtainedItems[reward.ID].ItemObject) as Accessory).AccessoryName + " " + _am.Items.ObtainedItems[reward.ID].IsObtained);

        RewardShow rs = Instantiate(RewardShow_PF, Camera.main.transform);
        rs.transform.position = new Vector3(0, 0, 10);
        rs.OnCreated(reward);
    }
}