using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New ItemDataBase", menuName = "Iventory System/Items/ItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    public List<ItemSO> items;

}
