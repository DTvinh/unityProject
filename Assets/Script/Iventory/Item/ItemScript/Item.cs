using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemSO itemInfor;
    public int amount;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        spriteRenderer.sprite = itemInfor.image;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            IventoryObject.Instance.AddItem(itemInfor, amount == 0 ? 1 : amount);
            Observer.Notify(CONSTANT.REFRESH_IVENTORY);
            // Destroy(gameObject);
            ItemDropSpawner.Instance.Despawn(gameObject);
        }
    }
    public void RefeshImage()
    {
        spriteRenderer.sprite = itemInfor.image;
    }
}
