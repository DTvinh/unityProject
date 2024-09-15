using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;


[System.Serializable]
public class IventorySlot
{

    public int id = -1;
    public ItemSO item;
    public int amount;
    public IventorySlot()
    {
        this.id = -1;
        this.item = null;
        this.amount = 0;
    }
    public IventorySlot(int id, ItemSO _item, int _amount)
    {
        this.id = id;
        this.item = _item;
        this.amount = _amount;
    }
    public void UpdateIventorySlot(int id, ItemSO _item, int _amount)
    {
        this.id = id;
        this.item = _item;
        this.amount = _amount;
    }


    public void AddAmount(int value)
    {
        amount += value;
    }
    public void RemoveItem(int value)
    {
        amount -= value;
    }

}
