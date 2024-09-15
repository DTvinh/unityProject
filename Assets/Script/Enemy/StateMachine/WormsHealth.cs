using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormsHealth : MonoBehaviour,IDamageAble
{
    [SerializeField] float health;

    public void TakeDamage(float _damage)
    {
        health -= _damage;
        if (health < 0)
        {
           Destroy(gameObject);
        }

    }
}
