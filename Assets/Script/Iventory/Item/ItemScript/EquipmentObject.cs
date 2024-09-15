using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equaipment Object", menuName = "Iventory System/Items/Equipment")]

public class EquimentObject : ItemSO
{
    // [SerializeField] float atkBonus;
    private void Awake()
    {
        type = ItemType.Equipment;
    }
}


