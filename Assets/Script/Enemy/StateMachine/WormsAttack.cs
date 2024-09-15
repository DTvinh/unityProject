using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WormsAttack : BaseState
{

    WormsStateMachine WS;
   
    float speedAttack;
    float damage;
    Transform attackPos;
    Vector2 attckArea = new Vector2(2f,2.5f);
    float timeBetweenAttack;
    float  timeAttack;


    public WormsAttack(WormsStateMachine stateMachine, float speedAttack,float damage,float timeAttack, Transform attackPos) : base(stateMachine)
    {
        WS = stateMachine;
        this.speedAttack = speedAttack;
        this.attackPos= attackPos;
        this.timeAttack = timeAttack;
        this.damage = damage;
    }
    public override void Enter()
    {
        base.Enter();
        Attack(damage);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();


        Attack(damage);
    }
    protected void Attack(float _damage)
    {

        Collider2D objectsToHit = Physics2D.OverlapBox(attackPos.position, attckArea, 0,WS.layer);
        
        timeBetweenAttack -= Time.deltaTime;
        if (objectsToHit != null && timeBetweenAttack <= 0)
        {
            IDamageAble isCanTakeDamage = objectsToHit.GetComponent<IDamageAble>();
            Debug.Log(" attack Player");
            isCanTakeDamage.TakeDamage(_damage);
            WS.animator.SetTrigger("Attacking");
            timeBetweenAttack = timeAttack;
        }

    }
}
