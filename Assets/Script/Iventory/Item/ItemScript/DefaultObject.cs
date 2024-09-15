using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Default Object", menuName = "Iventory System/Items/Default")]
public class DefaultObject : ItemSO
{
    private void Awake()
    {
        type = ItemType.Default;
    }
}
