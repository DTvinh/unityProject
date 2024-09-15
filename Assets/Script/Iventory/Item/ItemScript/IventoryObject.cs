using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Video;

public class IventoryObject : Singleton<IventoryObject>
{
    public EquipmentSlot[] EquipmentSlots = new EquipmentSlot[6];
    public IventorySlot[] iventory = new IventorySlot[36];
    public int gold = 0;
    public int Gold => gold;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        LoadIventory();
        Saving();
        Observer.Notify(CONSTANT.CHANGE_EQUIP);


    }
    public void AddItem(ItemSO _item, int _amount)
    {
        if (_item.itemName == "Gold")
        {
            gold += _amount;
            return;
        }
        if (_item.type == ItemType.Equipment)
        {
            SetEmptySlot(_item, _amount);
            return;
        }
        for (int i = 0; i < iventory.Length; i++)
        {
            if (iventory[i].id == _item.itemID)
            {

                // Debug.Log(" ++ amount");
                iventory[i].AddAmount(_amount);
                return;
            }

        }
        SetEmptySlot(_item, _amount);
    }

    public void UseEquiment(ItemSO _equipment)
    {

        if (_equipment.type == ItemType.Equipment)
        {
            SetEquipmentSlot(_equipment);
            return;
        }
    }
    public void ReduceAmount(ItemSO _item, int index)
    {
        for (int i = 0; i < iventory.Length; i++)
        {
            if (_item.itemID == iventory[i].id)
            {
                iventory[i].RemoveItem(1);
                if (iventory[i].amount <= 0)
                {
                    RemoveItem(_item, index);
                }
            }
        }
    }
    public IventorySlot SetEmptySlot(ItemSO item, int amount)
    {

        for (int i = 0; i < iventory.Length; i++)
        {

            if (iventory[i].id <= -1)
            {
                iventory[i].UpdateIventorySlot(item.itemID, item, amount);
                return iventory[i];
            }
        }
        return null;
    }


    public void RemoveItem(ItemSO _item, int index)
    {

        for (int i = 0; i < iventory.Length; i++)
        {

            if (iventory[i].id == _item.itemID && i == index)
            {
                iventory[i].UpdateIventorySlot(-1, null, 0);
            }
        }
    }

    public EquipmentSlot SetEquipmentSlot(ItemSO _item)
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            if (_item.equipmentType == EquipmentSlots[i].type)
            {
                {
                    if (EquipmentSlots[i].equipment != null)
                    {
                        AddItem(EquipmentSlots[i].equipment, 1);
                    }
                    EquipmentSlots[i].UpdateEquip(_item.itemID, _item);
                    return EquipmentSlots[i];

                }
            }
        }

        return null;
    }

    public void RemoveEquip(ItemSO _item)
    {

        for (int i = 0; i < EquipmentSlots.Length; i++)
        {

            if (EquipmentSlots[i].id == _item.itemID)
            {
                EquipmentSlots[i].UpdateEquip(-1, null);
            }
        }
    }


    void Saving()
    {

        SaveIventory();
        Invoke(nameof(Saving), 5f);

    }
    public void SaveIventory()
    {
        Debug.Log("save data");
        string saveData = JsonUtility.ToJson(this, true);
        string fliePath = Application.persistentDataPath + "/DataIventory.json";
        File.WriteAllText(fliePath, saveData);
        Debug.Log(fliePath);

    }

    public void LoadIventory()
    {
        if (File.Exists(Application.persistentDataPath + "/DataIventory.json"))
        {
            string saveDataItem = File.ReadAllText(Application.persistentDataPath + "/DataIventory.json");
            JsonUtility.FromJsonOverwrite(saveDataItem, this);
        }
    }
}










