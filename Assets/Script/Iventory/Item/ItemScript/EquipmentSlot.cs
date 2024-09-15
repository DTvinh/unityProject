using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[System.Serializable]

public class EquipmentSlot
{

    public int id;
    public EquipmentType type;
    public ItemSO equipment;

    public EquipmentSlot()
    {
        this.id = -1;
        this.equipment = null;
    }


    public void UpdateEquip(int _id, ItemSO _item)
    {
        this.id = _id;
        this.equipment = _item;
    }

}
