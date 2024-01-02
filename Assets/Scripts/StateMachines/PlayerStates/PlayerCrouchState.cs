using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    private readonly int CrouchHash = Animator.StringToHash("PlayerCrouch");
    private const float CrossFadeDuration = 1f;
    public PlayerCrouchState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(CrouchHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if(!stateMachine.InputReader.isCrouch)
        {
           stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
       }
    }
    
    public override void Exit()
    {

    }

 
}
