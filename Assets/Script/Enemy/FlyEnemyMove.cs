using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyEnemyMove : EnemyMove
{
    // Start is called before the first frame update

    Vector3 posOldPlace;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        posOldPlace = transform.position + new Vector3(Random.Range(-2f, 4f), Random.Range(1f, 3f));
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        // MoveAnimation();
    }
    protected virtual void MoveAnimation()
    {
        animator.SetBool("IsRuning", true);
        if (enemyAttack.objectsToHit.Length > 0) { animator.SetBool("IsRuning", false); }
    }

    protected override void Move()
    {

        if (canFollow) { return; }
        transform.position = Vector2.MoveTowards(transform.position, posOldPlace, moveSpeed * Time.deltaTime);
        if (transform.position.x > posOldPlace.x)
        {
            lookingRight = false;
        }
        else
        {
            lookingRight = true;
        }


    }


    protected override void MoveFollowPlayer()
    {
        if (enemyAttack.objectsToHit.Length > 0) { return; }
        if (!canFollow) { return; }
        rb.velocity = new Vector2(0f, rb.velocity.y);
        transform.position = Vector2.MoveTowards(transform.position
        , new Vector2(PlayerController.Instance.transform.position.x
        , PlayerController.Instance.transform.position.y), moveSpeed * Time.deltaTime);

        if (PlayerController.Instance.transform.position.x >= transform.position.x)
        {
            lookingRight = true;
        }
        else
        {
            lookingRight = false;
        }
    }

    // protected override void 
}
