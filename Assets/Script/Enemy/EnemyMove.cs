using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody2D rb;
    protected Animator animator;
    // [SerializeField] protected float moveDistance;
    [SerializeField] protected float moveSpeed;
    // [SerializeField]protected Transform checkMove;
    protected bool lookingRight = true;
    // protected float directionRaycast;
    protected bool canFollow;
    [SerializeField] protected float distanceCanFollow;
    // protected float moveSpeedBF;
    // public LayerMask groundLayer;
    // protected RaycastHit2D hit;
    // protected RaycastHit2D hitDown;
    protected EnemyAttack enemyAttack;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();

    }
    protected virtual void Start()
    {

        moveSpeed = Random.Range(2f, 3f);

    }


    // Update is called once per frame
    protected virtual void Update()
    {
        // CheckRay();
        Flip();
        // MoveAnimation();
        CheckAllowFollowPlayer(distanceCanFollow);
        Move();
        MoveFollowPlayer();


    }

    // protected virtual void MoveAnimation()
    // {
    //     animator.SetBool("IsRuning", true);
    //     if (enemyAttack.objectsToHit.Length > 0) { animator.SetBool("IsRuning", false); }
    // }




    protected virtual void Flip()
    {

        if (lookingRight)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    protected virtual void Move()
    {
    }
    protected virtual void CheckAllowFollowPlayer(float distance)
    {
        if (Vector3.Distance(PlayerController.Instance.transform.position, transform.position) <= distance)
        {
            canFollow = true;
        }
        else { canFollow = false; }
    }
    protected virtual void MoveFollowPlayer()
    {
        // if (enemyAttack.objectsToHit.Length > 0) { return; }
        // if (!canFollow) { return; }
        // rb.velocity = new Vector2(0f, rb.velocity.y);
        // transform.position = Vector2.MoveTowards(transform.position
        // , new Vector2(PlayerController.Instance.transform.position.x
        // , transform.position.y), moveSpeed * Time.deltaTime);

        // if (PlayerController.Instance.transform.position.x >= transform.position.x)
        // {
        //     lookingRight = true;
        // }
        // else
        // {
        //     lookingRight = false;
        // }

    }
    protected virtual void CheckRay()
    {



    }


}
