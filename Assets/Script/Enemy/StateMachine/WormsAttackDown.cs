using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormsAttackDown :BaseState
{

    WormsStateMachine WS;
    bool CanAttackDown= true;

    public WormsAttackDown(WormsStateMachine stateMachine) : base(stateMachine)
    {

        WS = stateMachine;
    }

    //public override void Enter()
    //{
    //    base.Enter();
    //    if (CanAttackDown)
    //    {
    //        WS.StartCoroutine(AttckDown());
    //    }
    //}

    public override void UpdateLogic()
    {
       
        base.UpdateLogic();
        Debug.Log("vinh down");
        if (CanAttackDown)
        {
            WS.StartCoroutine(AttckDown());
        }
    }
    IEnumerator  AttckDown()
    {
        CanAttackDown= false;
        WS.animator.SetTrigger("AttackDown");
        
        yield return  new WaitForSeconds(3f);
        WS.transform.position = PlayerController.Instance.transform.position;
        WS.animator.SetTrigger("AttackTop");
        yield return new WaitForSeconds(5f);
        CanAttackDown = true; 
    }






}
