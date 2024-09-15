using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    public static ItemDropSpawner Instance;
    [SerializeField] private List<ItemSO> listItemSO = new List<ItemSO>();
    [SerializeField] private List<RareDropItem> rareDropItems = new List<RareDropItem>();

    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


    }
    protected override void Start()
    {
        base.Start();
        listItemSO = Resources.LoadAll<ItemSO>("ItemSOs").ToList();

    }

    // Update is called once per frame
    protected override void Update()
    {

    }

    public override GameObject Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        GameObject objItem = base.Spawn("Item", spawnPos, rotation);
        objItem.GetComponent<Item>().itemInfor = GetRandomItem() == null ? listItemSO[1] : GetRandomItem();
        objItem.GetComponent<Item>().amount = 1;
        objItem.GetComponent<Item>().RefeshImage();
        return objItem;
    }

    public ItemSO GetRandomItem()
    {
        float rate = Random.Range(1.0f, 100f);
        List<ItemSO> listItemByRarity = new List<ItemSO>();
        Debug.Log(rate);
        foreach (RareDropItem i in rareDropItems)
        {
            if (rate <= i.DropChance)
            {
                Debug.Log(i.rarity);
                listItemByRarity = listItemSO.FindAll(item => item.rarity == i.rarity);
                return listItemByRarity[Random.Range(0, listItemByRarity.Count)];
            }
            else
            {
                rate -= i.DropChance;
            }

        }

        return null;

    }



}


[System.Serializable]
public class RareDropItem
{
    public Rarity rarity;
    [SerializeField] float dropChance;
    public float DropChance => dropChance;




}
