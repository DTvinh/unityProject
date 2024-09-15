using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState baseState;
    public void Start()
    {
        
        baseState = GetInitialState();
        if(baseState != null)
        {

            baseState.Enter();
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (baseState != null)
        {
            baseState.UpdateLogic();
        } 

     }
    private void LateUpdate()
    {
        if (baseState != null)
        {
            baseState.UpdatePhysics();
        }
    }

    public void ChangeState( BaseState newstate )
    {
        
        baseState = newstate;
        //baseState.Enter();
    }


    protected virtual BaseState GetInitialState() { 
        return null;
    
    }

} 



