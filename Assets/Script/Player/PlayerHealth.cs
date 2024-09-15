using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour, IDamageAble
{
    private float health;
    [SerializeField] private float maxHealth;
    public Slider healthSlider;
    Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }
    private void Update()
    {

    }
    public void TakeDamage(float _damage)
    {
        health -= Mathf.RoundToInt(_damage);
        healthSlider.value = health;
        animator.SetTrigger("TakeDamege");

        if (health <= 0)
        {
            Debug.Log("bi can chet");

        }
    }
}
