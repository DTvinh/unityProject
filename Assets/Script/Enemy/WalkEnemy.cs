using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : EnemyMove
{

    [SerializeField] protected float moveDistance;
    // [SerializeField]protected  float moveSpeed;
    [SerializeField] protected Transform checkMove;

    protected float directionRaycast;
    protected float moveSpeedBF;
    public LayerMask groundLayer;
    protected RaycastHit2D hit;
    protected RaycastHit2D hitDown;
    protected override void Awake()
    {
        base.Awake();

    }
    protected override void Start()
    {
        base.Start();
        directionRaycast = 1;
        moveSpeedBF = moveSpeed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        MoveAnimation();
        DirectionRayCast();
        CheckRay();
    }


    protected virtual void MoveAnimation()
    {
        animator.SetBool("IsRuning", true);
        if (enemyAttack.objectsToHit.Length > 0) { animator.SetBool("IsRuning", false); }
    }
    protected override void Move()
    {

        if (canFollow) { return; }
        moveSpeed = moveSpeedBF;
        if (lookingRight)
        {
            rb.velocity = Vector2.right * moveSpeed;
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            rb.velocity = Vector2.left * moveSpeed;
            transform.localScale = new Vector3(-1, 1, 0);
        }


    }

    protected override void CheckRay()
    {

        hit = Physics2D.Raycast(checkMove.transform.position, Vector2.right * DirectionRayCast(), moveDistance, groundLayer);

        hitDown = Physics2D.Raycast(checkMove.transform.position, Vector2.down, moveDistance, groundLayer);
        //Debug.DrawRay(checkMove.transform.position, Vector2.right, Color.yellow, moveDistance);

        Debug.DrawRay(checkMove.transform.position, Vector2.down, Color.yellow, moveDistance);
        if (canFollow && !hitDown)
        {
            moveSpeed = 0;
            animator.SetBool("IsRuning", false);

        }
        if (canFollow)
        {
            return;
        }
        else
        {

            if (hit.collider != null && lookingRight || hitDown.collider == null && lookingRight)
            {
                lookingRight = false;
            }
            else if (hit.collider != null && lookingRight == false || hitDown.collider == null && lookingRight == false)
            {
                lookingRight = true;
            }
        }
    }
    protected override void MoveFollowPlayer()
    {
        if (enemyAttack.objectsToHit.Length > 0) { return; }
        if (!canFollow) { return; }
        rb.velocity = new Vector2(0f, rb.velocity.y);
        transform.position = Vector2.MoveTowards(transform.position
        , new Vector2(PlayerController.Instance.transform.position.x
        , transform.position.y), moveSpeed * Time.deltaTime);

        if (PlayerController.Instance.transform.position.x >= transform.position.x)
        {
            lookingRight = true;
        }
        else
        {
            lookingRight = false;
        }

    }
    private int DirectionRayCast()
    {
        int d = 1;
        if (lookingRight)
        {
            d = 1;
        }
        else
        {
            d = -1;
        }
        return d;
    }


}
