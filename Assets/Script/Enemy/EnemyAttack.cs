using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;

    [SerializeField] protected float damage;
    [SerializeField] protected float timeAttack;
    protected float timeBetweenAttack;
    [SerializeField] protected Vector2 attckArea;
    public LayerMask LayerAble;
    public Collider2D[] objectsToHit;

    public Transform attackPos;
    IDamageAble CanTakedamage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    protected void Start()
    {


    }

    protected void Update()
    {
        Attack();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, attckArea);

    }
    protected void Attack()
    {

        objectsToHit = Physics2D.OverlapBoxAll(attackPos.position, attckArea, 0, LayerAble);

        timeBetweenAttack -= Time.deltaTime;
        if (objectsToHit.Length > 0)
        {
            for (var i = 0; i < objectsToHit.Length; i++)
            {

                CanTakedamage = objectsToHit[i].GetComponent<IDamageAble>();
                if (CanTakedamage != null && timeBetweenAttack <= 0)
                {
                    animator.SetTrigger("Attacking");

                    timeBetweenAttack = timeAttack;
                }

            }


        }

    }

    protected void Attacking()
    {
        CanTakedamage.TakeDamage(damage);
    }


}
