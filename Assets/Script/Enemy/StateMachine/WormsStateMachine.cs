using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class WormsStateMachine : StateMachine
{

    public Animator animator;
    private Rigidbody rb;
    public PlayerController Player ;
    [SerializeField] protected float speedRun;
    private WormsRun wormsRun;
    bool canChangeState=true;

    [Header(" Attack ")]
    [SerializeField] float speedAttack;
    [SerializeField] Transform attackPos;
    [SerializeField] float damage;
    [SerializeField] float timeBetweenAttack;
    [SerializeField] float timeAttack;
    private WormsAttack wormsAttack;
    private WormsAttackDown wormsAttackDown;
    public LayerMask layer;


    [Header("Spawn Rocks")]
    [SerializeField] float spawnQantity;
    [SerializeField] float timeSpawn;
    [SerializeField] Transform limit1;
    [SerializeField] Transform limit2;
    [SerializeField] GameObject rock;
    private WormsCreateRocks wormsCreateRocks;
    [SerializeField] List<BaseState> stateList;
    int randumList;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
        wormsRun = new WormsRun(this,speedRun);
        wormsAttack= new WormsAttack(this,speedAttack,damage,timeAttack,attackPos);
        wormsAttackDown = new WormsAttackDown(this);
        wormsCreateRocks=new WormsCreateRocks(this,rock);
        stateList= new List<BaseState> { wormsAttackDown, wormsCreateRocks };
          Player = PlayerController.Instance;
    }
    void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Flip();

        if (canChangeState)
        {
            StartCoroutine(nextState());
        }

    }
    private void LateUpdate()
    {
       wormsRun.UpdatePhysics();
        wormsAttack.UpdatePhysics();
    }


    IEnumerator nextState()
    {
        canChangeState= false;
         randumList = Random.Range(0, stateList.Count);
        //Debug.Log(stateList[randumList].ToString());
        yield return new WaitForSeconds(5f);
        ChangeState(stateList[randumList]);
        yield return new WaitForSeconds(3f);
        canChangeState = true;


    }


    //protected override BaseState GetInitialState()
    //{
    //    int randumList = Random.Range(0, stateList.Count);

    //    Debug.Log(randumList);
    //    return stateList[randumList];
    //}

    public void Flip()
    {
        if (transform.position.x <= PlayerController.Instance.transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
    }


   

    public void SpawnRocks( GameObject rock)
    {


        for (int i = 0; i <= spawnQantity; i++) {
             Instantiate(rock, new Vector3(Random.Range(limit1.position.x, limit2.position.x), Random.Range(11f, 12f), 2f), Quaternion.identity);

        }
        //if (this.rockList.Count>= spawnQantity) return;
        //GameObject rockobject =

        //this.rockList.Add(rockobject);

        //Debug.Log("vinh");


    }


  
}
