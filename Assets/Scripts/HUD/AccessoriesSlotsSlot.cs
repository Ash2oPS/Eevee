using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoriesSlotsSlot : MonoBehaviour
{
    [SerializeField]
    private AccessorySlotUI[] _slots;

    public void AssignSlots(ObtainedItem[] oi, ChangeEevee ce, AccessoryDescription ad)
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].AssignAccessory(oi[i].ItemObject as Accessory, ce, ad, oi[i].IsObtained);
        }
    }
}