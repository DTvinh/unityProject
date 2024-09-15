using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ItemEvent : Singleton<ItemEvent>
{
    [SerializeField] private Transform movingItem;
    [SerializeField] private Transform oldPerant;
    [SerializeField] private UiIventory uiIventory;
    [SerializeField] private Transform targetSlot;
    [SerializeField] private Transform[] BtnCtrl;
    public Transform IUDetailItem;
    private IventoryObject iventoryObject;
    ItemSO itemSOClick = null;
    int indexSlot = 0;
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        iventoryObject = IventoryObject.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (movingItem != null)
        {
            TargetSlotItem();
        }
    }

    void TargetSlotItem()
    {
        Vector2 mousePos = Input.mousePosition;
        movingItem.position = mousePos;
        foreach (Transform s in uiIventory.ItemSlots)
        {
            if (Vector2.Distance(movingItem.position, s.position) <= 20f)
            {
                targetSlot = s;
            }
        }


    }


    public void SetMovingItem(Transform _item)
    {
        movingItem = _item;
        oldPerant = _item.parent;
        _item.SetParent(this.transform);
    }

    public void removeMovingItem()
    {

        if (movingItem != null)
        {


            if (targetSlot != null)
            {
                if (targetSlot.childCount != 0)
                {
                    Transform childSlot = targetSlot.GetChild(0);
                    childSlot.SetParent(oldPerant);
                    childSlot.localPosition = Vector3.zero;
                }
                movingItem.SetParent(targetSlot);

            }
            if (targetSlot == null)
            {

                movingItem.SetParent(oldPerant);
            }
            movingItem.localPosition = Vector3.zero;

        }

        movingItem = null;
        targetSlot = null;
    }
    public void ClickItem(Transform slot, IventorySlot _iventorySlot, int _indexSlot)
    {
        if (_iventorySlot.item == null)
        {
            return;
        }

        this.indexSlot = _indexSlot;
        this.itemSOClick = _iventorySlot.item;
        this.IUDetailItem.gameObject.SetActive(true);
        this.BtnCtrl[0].gameObject.SetActive(true);
        this.BtnCtrl[1].gameObject.SetActive(false);
        Transform itemDetail = IUDetailItem.GetChild(0);
        itemDetail.Find("TxtNameItem").GetComponent<TextMeshProUGUI>().text = _iventorySlot.item.itemName;
        itemDetail.Find("TxtNameItem").GetComponent<TextMeshProUGUI>().color = GetColor(_iventorySlot.item.rarity);
        itemDetail.Find("TxtDescriptionItem").GetComponent<TextMeshProUGUI>().text = ScanStats(_iventorySlot.item);
    }
    public void ClickEquipment(Transform slot, EquipmentSlot _equipmentSlot)
    {
        if (_equipmentSlot.equipment == null)
        {
            return;
        }
        itemSOClick = _equipmentSlot.equipment;
        IUDetailItem.gameObject.SetActive(true);
        BtnCtrl[1].gameObject.SetActive(true);
        BtnCtrl[0].gameObject.SetActive(false);
        Transform itemDetail = IUDetailItem.GetChild(0);

        itemDetail.Find("TxtNameItem").GetComponent<TextMeshProUGUI>().text = _equipmentSlot.equipment.itemName;
        itemDetail.Find("TxtNameItem").GetComponent<TextMeshProUGUI>().color = GetColor(_equipmentSlot.equipment.rarity);
        itemDetail.Find("TxtDescriptionItem").GetComponent<TextMeshProUGUI>().text = ScanStats(_equipmentSlot.equipment);
    }
    public Color GetColor(Rarity rarity)
    {
        if (rarity == Rarity.Divine)
        {
            Debug.Log(Rarity.Divine);
            // return new Color(255, 0, 0, 255);
            return new Color(255, 0, 0, 255);

        }
        if (rarity == Rarity.Common)
        {
            return new Color(255, 255, 255, 255);
        }
        if (rarity == Rarity.Uncommon)
        {
            return new Color(0, 255, 0, 255);
        }
        if (rarity == Rarity.Rare)
        {
            return new Color(0, 0, 255, 255);
        }
        if (rarity == Rarity.Epic)
        {
            return new Color(125, 0, 115, 255);
        }
        if (rarity == Rarity.Legendary)
        {
            Debug.Log(Rarity.Legendary);
            return new Color(224, 179, 0, 255);
        }

        return new Color(255, 255, 255, 255);
    }

    public string ScanStats(ItemSO _item)
    {
        string itemDescription = "";

        if (_item.buffs.Length > 0)
        {
            for (int i = 0; i < _item.buffs.Length; i++)
            {
                itemDescription += _item.buffs[i].attribute.ToString() + "    + " + _item.buffs[i].value + "\n";
            }
            return _item.description + "\n" + itemDescription;
        }
        return _item.description;
    }

    public void UpdateDiscardItem()
    {
        IUDetailItem.gameObject.SetActive(false);
        iventoryObject.RemoveItem(itemSOClick, indexSlot);
        Observer.Notify(CONSTANT.REFRESH_IVENTORY);

    }
    public void UseItem()
    {
        IUDetailItem.gameObject.SetActive(false);
        if (itemSOClick.type == ItemType.Equipment)
        {
            iventoryObject.UseEquiment(itemSOClick);
            iventoryObject.RemoveItem(itemSOClick, indexSlot);
            Observer.Notify(CONSTANT.CHANGE_EQUIP);
        }
        if (itemSOClick.type == ItemType.Fool)
        {
            EatFool(itemSOClick);
        }
        Observer.Notify(CONSTANT.REFRESH_IVENTORY);
    }
    public void EatFool(ItemSO item)
    {

        iventoryObject.ReduceAmount(item, indexSlot);

    }
    public void UseHP()
    {
        // IventorySlot HpItem = iventoryObject.iventory.FirstOrDefault(i => i.id == 2);
        // for (int i = 0; i <= iventoryObject.iventory.Length; i++)
        // {
        //     if (iventoryObject.iventory[i].id == 2)
        //     {
        //         iventoryObject.ReduceAmount(iventoryObject.iventory[i].item, i);
        //         Observer.Notify(CONSTANT.REFRESH_IVENTORY);
        //         return;
        //     }
        // }
        // return;

    }



    public void RemoveEquip()
    {
        IUDetailItem.gameObject.SetActive(false);
        iventoryObject.AddItem(itemSOClick, 1);
        iventoryObject.RemoveEquip(itemSOClick);
        Observer.Notify(CONSTANT.REFRESH_IVENTORY);
        Observer.Notify(CONSTANT.CHANGE_EQUIP);

    }

}
