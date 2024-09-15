using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UiIventory : MonoBehaviour
{

    // DragItem dragItem;
    [SerializeField] Transform prefabItem;
    [SerializeField] Transform prefabSlot;
    [SerializeField] int quatitySlot;



    [SerializeField] IventoryObject iventoryObject;
    [SerializeField] List<Transform> itemSlots;
    [SerializeField] private TextMeshProUGUI amountGold;
    public List<Transform> ItemSlots => itemSlots;

    // Dictionary<IventorySlot, Transform> itemDisplay = new Dictionary<IventorySlot, Transform>();
    Dictionary<Transform, IventorySlot> itemDisplay = new Dictionary<Transform, IventorySlot>();



    private void Awake()
    {
        Observer.AddListener(CONSTANT.REFRESH_IVENTORY, UpdateSlot);
    }
    void OnEnable()
    {

    }
    void Start()
    {
        CreateSlot();
        // UpdateSlot();

        Debug.LogWarning(CONSTANT.REFRESH_IVENTORY);
        Observer.Notify(CONSTANT.REFRESH_IVENTORY);
        Observer.Notify(CONSTANT.CHANGE_EQUIP);

        // Init();
    }


    // Update is called once per frame
    void Update()
    {
        // UpdateSlot();
    }
    private void CreateSlot()
    {
        // itemDisplay = new Dictionary<Transform, IventorySlot>();
        for (int i = 0; i < iventoryObject.iventory.Length; i++)
        {
            Transform newSlot = Instantiate(prefabSlot, this.transform);
            itemDisplay.Add(newSlot, iventoryObject.iventory[i]);
            itemSlots.Add(newSlot);
            AddEventTrigger(newSlot.GetChild(0), itemDisplay[newSlot], i);
        }

    }



    void UpdateSlot(object[] datas)
    {
        amountGold.text = iventoryObject.Gold.ToString();
        foreach (var item in itemSlots)
        {

            if (itemDisplay[item].id >= 0)
            {
                item.GetChild(0).GetComponent<Image>().sprite = itemDisplay[item].item.image;
                item.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                item.GetComponentInChildren<TextMeshProUGUI>().text = itemDisplay[item].amount == 1 ? " " : itemDisplay[item].amount.ToString();
            }
            else
            {
                item.GetChild(0).GetComponent<Image>().sprite = null;
                item.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                item.GetComponentInChildren<TextMeshProUGUI>().text = " ";

            }
        }
    }


    // void Init()
    // {
    //     for (int i = 0; i < iventoryObject.iventory.Length; i++)
    //     {

    //         AddItemSlot(itemSlots[i], iventoryObject.iventory[i]);
    //     }
    // }

    private void AddItemSlot(Transform slot, IventorySlot _iventorySlot)
    {

        var newObjItem = Instantiate(prefabItem, SlotEmpty());
        // AddEventTrigger(newObjItem, _iventorySlot);
        newObjItem.GetComponent<Image>().sprite = _iventorySlot.item.image;
        newObjItem.GetChild(0).GetComponent<TextMeshProUGUI>().text = _iventorySlot.amount.ToString();
        // itemDisplay.Add(_iventorySlot, newObjItem);
    }





    Transform SlotEmpty()
    {

        Transform slotEmpty = null;
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (itemSlots[i].childCount != 0)
            {
                continue;
            }
            if (itemSlots[i].childCount == 0)
            {
                slotEmpty = itemSlots[i];
                break;
            }
        }
        return slotEmpty;
    }

    public void AddEventTrigger(Transform newItem, IventorySlot _iventorySlot, int indexSlot)
    {
        EventTrigger eventTrigger = newItem.GetComponent<EventTrigger>();
        // var mouseDown = new EventTrigger.Entry
        // {
        //     eventID = EventTriggerType.PointerDown
        // };
        // mouseDown.callback.AddListener(eventData =>
        // {
        //     ItemEvent.Instance.SetMovingItem(newItem);
        // });
        // eventTrigger.triggers.Add(mouseDown);




        // var mouseUp = new EventTrigger.Entry
        // {
        //     eventID = EventTriggerType.PointerUp
        // };
        // mouseUp.callback.AddListener(eventData =>
        // {
        //     ItemEvent.Instance.removeMovingItem();
        // });
        // eventTrigger.triggers.Add(mouseUp);

        var Click = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick
        };
        Click.callback.AddListener(eventData =>
        {
            ItemEvent.Instance.ClickItem(newItem, _iventorySlot, indexSlot);
        });
        eventTrigger.triggers.Add(Click);

    }
}
