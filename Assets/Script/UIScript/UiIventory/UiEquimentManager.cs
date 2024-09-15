using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UiEquimentManager : MonoBehaviour
{
    [SerializeField] IventoryObject iventory;
    [SerializeField] Transform prefabSlot;

    [SerializeField] List<Transform> Slots = new List<Transform>();

    Dictionary<Transform, EquipmentSlot> itemDisplay = new Dictionary<Transform, EquipmentSlot>();
    private void Start()
    {
        CreateSlot();

    }
    private void Update()
    {
        UpdateEquipment();
    }

    private void CreateSlot()
    {
        itemDisplay = new Dictionary<Transform, EquipmentSlot>();
        for (int i = 0; i < iventory.EquipmentSlots.Length; i++)
        {

            Transform newObj = Instantiate(prefabSlot, this.transform);
            itemDisplay.Add(newObj, iventory.EquipmentSlots[i]);
            Slots.Add(newObj);
            AddEventTrigger(newObj.GetChild(0), itemDisplay[newObj]);
        }

    }
    private void UpdateEquipment()
    {

        foreach (var Slot in Slots)
        {

            if (itemDisplay[Slot].id >= 0)
            {

                Slot.GetChild(0).GetComponent<Image>().sprite = itemDisplay[Slot].equipment.image;
                Slot.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                // Slot.GetComponentInChildren<TextMeshProUGUI>().text = itemDisplay[Slot].amount == 1 ? " " : itemDisplay[Slot].amount.ToString();
            }
            else
            {
                Slot.GetChild(0).GetComponent<Image>().sprite = null;
                Slot.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                // item.GetComponentInChildren<TextMeshProUGUI>().text = " ";
            }
        }
    }

    public void AddEventTrigger(Transform newItem, EquipmentSlot _equipmentSlot)
    {
        EventTrigger eventTrigger = newItem.GetComponent<EventTrigger>();

        var Click = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick
        };
        Click.callback.AddListener(eventData =>
        {
            ItemEvent.Instance.ClickEquipment(newItem, _equipmentSlot);
        });
        eventTrigger.triggers.Add(Click);
    }



}


