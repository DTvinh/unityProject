using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState 
{

     protected StateMachine stateMachine;

    public BaseState( StateMachine stateMachine)
    {
        
        this.stateMachine = stateMachine;
    }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }

    public virtual void Exit() { }
    public virtual void Enter() { }
}
