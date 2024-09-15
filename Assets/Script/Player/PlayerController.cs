using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public PlayerStateList pState;

    private Animator animator;
    float moveInput;
    bool jumpInput;
    bool isGrounded;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;
    Vector2 vecGravity;


    [SerializeField] private float speedClimb;
    private float moveY;
    [SerializeField] private Transform WallCheck;
    [SerializeField] private Vector2 wallCheckDistance;
    bool isWallDistance;
    bool isClembing;
    private float initialGratityScale;


    private CapsuleCollider2D CapsuleCollider;
    private Vector2 colliderSize;
    private Vector2 slopeNormalPerp;
    private float slopeDownEngle;
    private float slopeDownEngleOld;
    [SerializeField] private float slopeCheckDistance;
    private bool isOnSlope;



    [Header("ledge Infor")]
    [SerializeField] public bool ledgeDeteced;
    [SerializeField] private Vector2 offSet1;
    [SerializeField] private Vector2 offSet2;
    private Vector2 climbegunPosition;
    private Vector2 climOverPosition;
    private bool canGrabLedge = true;
    private bool canClimb;
    [SerializeField] List<PhysicsMaterial2D> physicsMaterial2D = new List<PhysicsMaterial2D>();


    [Header("Dash")]
    [SerializeField] private float dashDistance;
    [SerializeField] private float dashingPower;
    [SerializeField] private float timeDash;
    private bool inputDash;
    private bool isDashing = true;
    bool notDash = true;


    protected override void Awake()
    {
        base.Awake();
        pState = GetComponent<PlayerStateList>();
        rb = GetComponent<Rigidbody2D>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        colliderSize = CapsuleCollider.size;



    }
    void Start()
    {
        initialGratityScale = rb.gravityScale;
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();
        WallClimb();
        IsRuning();
        Jump();
        Dash();
        ClimbLegde();
        if (inputDash && pState.canDash)
        {
            notDash = false;
            StartCoroutine(StopDashing());
        }


    }
    private void FixedUpdate()
    {
        SlopeCheck();
    }

    private void GetInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetKeyDown(KeyCode.Space);

        moveY = Input.GetAxisRaw("Vertical");
        inputDash = Input.GetKey(KeyCode.LeftShift);
    }


    private void IsRuning()
    {


        rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        animator.SetBool("IsRuning", moveInput != 0);
        Flip();
        if (moveInput == 0 && isGrounded)
        {
            rb.sharedMaterial = physicsMaterial2D[1];
        }
        else
        {
            rb.sharedMaterial = physicsMaterial2D[0];

        }

        //if (isGrounded && !isOnSlope)
        //{
        //    rb.velocity = new Vector2(moveInput * runSpeed, 0.0f);
        //}
        if (moveInput != 0 && isGrounded && isOnSlope)
        {
            rb.velocity = new Vector2(runSpeed * slopeNormalPerp.x * -moveInput, 0f);
            if (jumpInput || moveY != 0)
            {
                rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
            }

        }
        //else if (!isGrounded) {
        //    rb.velocity = new Vector2(moveInput * runSpeed, rb.velocity.y);
        //}




    }


    private void Flip()
    {
        if (moveInput != 0)
        {

            animator.SetBool("IsRuning", isGrounded);

            if (moveInput > 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
                pState.lookingRight = true;

            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 0);
                pState.lookingRight = false;
            }
        }
    }
    private void SlopeCheck()
    {
        Vector2 checkPos = transform.position - new Vector3(0.0f, colliderSize.y / 2);
        SlopeCheckVertical(checkPos);
    }
    private void SlopeCheckHorizontal(Vector2 checkPos)
    {

    }
    private void SlopeCheckVertical(Vector2 checkPos)
    {

        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, groundLayer);
        if (hit)
        {
            slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownEngle = Vector2.Angle(hit.normal, Vector2.up);
            if (slopeDownEngle != slopeDownEngleOld)
            {
                isOnSlope = true;
            }
            else
            {
                isOnSlope = false;
            }
            slopeDownEngle = slopeDownEngleOld;
            //Debug.DrawRay(hit.point, slopeNormalPerp, Color.blue);
            //Debug.DrawRay(hit.point, hit.normal, Color.yellow);
        }
    }



    private void Jump()
    {
        animator.SetFloat("yVelocity", rb.velocity.y);
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.5f, 0.4f), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (jumpInput && isGrounded || jumpInput && isWallDistance)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);


        }

        if (rb.velocity.y <= 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        animator.SetBool("IsJump", jumpInput);
        animator.SetBool("IsJump", !isGrounded);


        //if(!isGrounded && attackInput)
        //{

        //animator.SetTrigger("Attacking");
        //}


    }


    private void WallClimb()
    {
        isWallDistance = Physics2D.OverlapBox(WallCheck.position, wallCheckDistance, 0, groundLayer);

        if (isWallDistance && moveY != 0)
        {

            isClembing = true;

        }
        else
        {
            isClembing = false;

        }

        if (isClembing)
        {
            rb.gravityScale = 0;
            animator.SetBool("Climbing", true);
            rb.velocity = new Vector2(0, moveY * speedClimb);
        }
        else
        {
            animator.SetBool("Climbing", false);
            rb.gravityScale = initialGratityScale;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(WallCheck.position, wallCheckDistance);
    }
    private void Dash()
    {
        if (notDash) return;
        rb.velocity = new Vector2(dashingPower * transform.localScale.x, rb.velocity.y);


    }


    IEnumerator StopDashing()
    {

        animator.SetTrigger("IsDashing");
        pState.canDash = false;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(dashDistance);
        rb.velocity = new Vector2(0f, rb.velocity.y);
        notDash = true;
        rb.gravityScale = originalGravity;
        yield return new WaitForSeconds(timeDash);
        pState.canDash = true;
    }

    private void ClimbLegde()
    {
        animator.SetBool("LedgeClimb", canClimb);

        if (ledgeDeteced && canGrabLedge)
        {

            ledgeDeteced = false;
            canClimb = true;
            canGrabLedge = false;

            return;
            //Invoke("ClimbLedgeOver",0.25f);
            //if (pState.lookingRight)
            //{
            //    transform.position = new Vector3(transform.position.x + 0.95f, transform.position.y + 1.5f);
            //    
            //}
            //else
            //{
            //    transform.position = new Vector3(transform.position.x - 0.978f, transform.position.y + 1.5f);
            //    rb.velocity = new Vector3(rb.velocity.x, 0f);
            //}

        }
        if (canClimb)
        {

            rb.velocity = new Vector3(0f, 0f);
        }



    }
    private void ClimbLedgeOver()
    {
        ledgeDeteced = false;
        canClimb = false;
        if (pState.lookingRight)
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y + 1.5f);

        }
        else
        {
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y + 1.5f);

        }

        Invoke("AllowLedgeGrab", 0.1f);


    }
    private void AllowLedgeGrab() => canGrabLedge = true;



    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     var item = other.gameObject.GetComponent<Item>();
    //     if (item)
    //     {

    //         IventoryObject.Instance.AddItem(item.itemInfor, item.amount == 0 ? 1 : item.amount);
    //         Observer.Notify(CONSTANT.REFRESH_IVENTORY);
    //         Destroy(other.gameObject);
    //     }
    // }
}







//-------------------------------------------------------------
