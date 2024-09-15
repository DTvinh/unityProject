// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public interface AddEventTrigger 
// {
//     public void AddOnPointerDown(Transform Obj, Action action){
//          EventTrigger eventTrigger = Obj.GetComponent<EventTrigger>();
//         var mouseDown = new EventTrigger.Entry
//         {
//             eventID = EventTriggerType.PointerDown
//         };
//         mouseDown.callback.AddListener(eventData =>
//         {
//             dragItem.SetMovingItem(newItem);
//         });
//         eventTrigger.triggers.Add(mouseDown);


//     }


//         private void AddEventTrigger(Transform newItem, IventorySlot _iventorySlot)
//     {
//         var mouseUp = new EventTrigger.Entry
//         {
//             eventID = EventTriggerType.PointerUp
//         };
//         mouseUp.callback.AddListener(eventData =>
//         {
//             dragItem.removeMovingItem();
//         });
//         eventTrigger.triggers.Add(mouseUp);


//         var Click = new EventTrigger.Entry
//         {
//             eventID = EventTriggerType.PointerClick
//         };
//         mouseUp.callback.AddListener(eventData =>
//         {
//             dragItem.ClickItem(_iventorySlot);
//         });
//         eventTrigger.triggers.Add(mouseUp);





//     }


//     }
