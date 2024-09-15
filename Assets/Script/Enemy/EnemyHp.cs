using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour, IDamageAble
{

    Rigidbody2D rb;
    Animator animator;
    protected float health;
    public float Health => health;
    [SerializeField] protected float maxHealth;
    private float timer = 10f;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float _damage)
    {
        animator.SetTrigger("TakeHit");
        health -= Mathf.RoundToInt(_damage);

        if (health <= 0)
        {
            // Destroy(gameObject);
            // gameObject.SetActive(false);
            EnemySpawner.Instance.Despawn(gameObject);
            // SpawnerRefresh();

            Invoke("SpawnerRefresh", timer);
            DropItem();
        }
    }

    void SpawnerRefresh()
    {
        GameObject enemyObj = EnemySpawner.Instance.Spawn(gameObject.name, transform.parent.position, Quaternion.identity);
        health = maxHealth;
        enemyObj.SetActive(true);
    }
    private void DropItem()
    {
        float rate = Random.Range(0f, 11f);
        // Debug.Log(rate);

        if (rate >= 8)
        {
            GameObject item = ItemDropSpawner.Instance.Spawn("Item", this.transform.position, Quaternion.identity);
            item.SetActive(true);
            item.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 6));

        }


    }


}
