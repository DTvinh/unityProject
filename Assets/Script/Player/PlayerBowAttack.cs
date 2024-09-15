using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowAttack : PlayerAttack
{

    bool attackClick;
    bool holdBow;
    [SerializeField] GameObject arrow;
    [SerializeField] float speedArrow;


    private void Awake()
    {
        base.Awake();


    }
    protected override void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        InputAtatck();
        Attack();

    }

    private void InputAtatck()
    {
        holdBow = Input.GetMouseButtonDown(0);
        attackClick = Input.GetMouseButtonUp(0);
    }

    protected override void Attack()
    {

        timeSinceAttack += Time.deltaTime;
        if (attackClick && timeSinceAttack >= timeBetweenAttack)
        {
            timeSinceAttack = 0;
            shoot(arrow);
            animator.SetTrigger("BowAttack");
        }

        //if (holdBow) {
        //    animator.SetBool("Attack", true);
        //    animator.SetFloat("BowAttacking",0f);
        //    Debug.Log("ban");
        //}

    }



    void shoot(GameObject arrow)
    {

        GameObject objArrow = Instantiate(arrow, attackPos.position, Quaternion.identity);
        objArrow.GetComponent<Rigidbody2D>().velocity = objArrow.transform.right * speedArrow;
        if (player.pState.lookingRight)
        {
            objArrow.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            objArrow.transform.eulerAngles = new Vector2(objArrow.transform.eulerAngles.x, 180);
        }
    }

}
