using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUI : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup _slotsParent;

    [SerializeField]
    private ChangeEevee _changeEevee;

    [SerializeField]
    private AccessoryDescription _ad;

    [SerializeField]
    private AccessorySlotUI _slotPF;

    private void Start()
    {
        CreateSlots();
    }

    public void CreateSlots()
    {
        List<ObtainedItem> aoi = PlayerManager.Instance.AM.Items.ObtainedItems;

        foreach (ObtainedItem oi in aoi)
        {
            AccessorySlotUI slot = Instantiate(_slotPF, _slotsParent.transform);
            slot.AssignAccessory(oi.ItemObject as Accessory, _changeEevee, _ad);
        }
    }
}