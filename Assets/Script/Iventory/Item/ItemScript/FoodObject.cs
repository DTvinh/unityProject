using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Food Object", menuName = "Iventory System/Items/Food")]

public class FoodObject : ItemSO
{
    private void Awake()
    {
        type = ItemType.Fool;
    }
}
