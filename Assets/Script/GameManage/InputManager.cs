using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public float moveInput;
    public bool jumpInput;
    public float moveY;
    public bool inputDash;
    public bool inputShoot;
    public bool attackInput = false;
    public bool inputChangeWeapon;

    void Start()
    {

    }

    void Update()
    {
        GetInput();
        InputAttack();
    }


    public void GetInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.Space);

        moveY = Input.GetAxisRaw("Vertical");
        inputDash = Input.GetKey(KeyCode.LeftShift);
    }
    public virtual void InputAttack()
    {
        attackInput = Input.GetMouseButtonDown(0);
        inputShoot = Input.GetKeyDown(KeyCode.V);
        inputChangeWeapon = Input.GetKeyDown(KeyCode.F);

    }

}
