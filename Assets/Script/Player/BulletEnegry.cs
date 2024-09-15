using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletEnegry : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] GameObject effectExplosion;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnCollisionEnter2D(Collision2D _other)
    {
        if (_other.gameObject.layer == LayerMask.NameToLayer("Ground") || _other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            BulletSpawner.Instance.Despawn(gameObject);
            // GameObject newObj = EffectSpawner.Instance.Spawn(transform.position, Quaternion.identity);
            // newObj.SetActive(true);
            SpawnEffectExplosion(effectExplosion);
        }
    }


    void SpawnEffectExplosion(GameObject EffectExplosion)

    {
        GameObject OjEffectExplosion = EffectSpawner.Instance.Spawn(EffectSpawner.effectExplosion, transform.position, Quaternion.identity);
        OjEffectExplosion.SetActive(true);

    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
