using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class WormsCreateRocks : BaseState
{

     WormsStateMachine WS;
     GameObject Rock;
    bool canSpawn= true;
   



    public WormsCreateRocks(WormsStateMachine stateMachine, GameObject Rock) : base(stateMachine)
    {
        WS = stateMachine;
        this.Rock = Rock;




    }
    //public override void Enter()
    //{
    //    base.Enter();
    //    if (canSpawn)
    //    {
    //        WS.StartCoroutine(Spawn());
    //    }
    //}


    public override void UpdateLogic()
    {
        //WS.StartCoroutine(Spawn());
        base.UpdateLogic();
        //Spawner();
        if (canSpawn)
        {
            //WS.SpawnRocks(Rock);
            WS.StartCoroutine(Spawn());
        }
        

    }



    IEnumerator Spawn()
    {

        canSpawn = false;
        WS.animator.SetTrigger("AttackRoaring");
        
        yield return new WaitForSeconds(3f);
        WS.SpawnRocks(Rock);

        yield return new WaitForSeconds(4f);
        canSpawn = true;


    }
    //void Spawner()
    //{

    //    WS.StartCoroutine(Spawn());
    //    if (canSpawn)
    //    {
    //        WS.SpawnRocks(Rock);
    //    }

    //    return;
    //}
    public override void Exit()
    {
        base.Exit();
        canSpawn = false;

    }


}
