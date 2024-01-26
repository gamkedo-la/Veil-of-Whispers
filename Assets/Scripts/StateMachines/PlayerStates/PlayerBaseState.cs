using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;
    protected AudioState audioState;
    InputReader inputReader;
     
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        audioState = stateMachine.gameObject.GetComponent<AudioState>();
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
       // audioState.PlayFootStepSound();
    }


    protected void ReturnToLocomotion()
    {
       // audioState.StopFootStepSound();
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }


}
