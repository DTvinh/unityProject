using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WormsRun : BaseState
{
    private WormsStateMachine WS;
    private float speedRun;
    public WormsRun(WormsStateMachine stateMachine,float speedRun)  : base(stateMachine)
    {
        WS = stateMachine;
        this.speedRun = speedRun;
    }

    public override void Enter()
    {
        base.Enter();
        Moving();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();
        Moving();
    }
    public void Moving()
    {
        Debug.Log("Vinh abc");
        WS.transform.position = Vector2.MoveTowards(WS.transform.position
            , new Vector2(PlayerController.Instance.transform.position.x
            , WS.transform.position.y), speedRun * Time.deltaTime);
    }

    // Start is called before the first frame update
    
}
