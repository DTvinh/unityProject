using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    int currentState = 0;
    Animator animator;
    [SerializeField] RuntimeAnimatorController handAttack;
    [SerializeField] RuntimeAnimatorController swordAttack;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {

    }
    void Update()
    {
        Change();
    }
    private void Change()
    {
        if (InputManager.Instance.inputChangeWeapon)
        {

            if (currentState == 0)
            {
                currentState = 1;
                animator.runtimeAnimatorController = handAttack;

            }
            else if (currentState == 1)
            {
                currentState = 0;
                animator.runtimeAnimatorController = swordAttack;

            }


        }

    }

}
