using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRPunchState : PlayerBaseState
{
    private readonly int PlayerPunchHash = Animator.StringToHash("PlayerPunchRight");
    private const float CrossFadeDuration = 0.5f;
    float normalizedTime;


    public PlayerRPunchState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        stateMachine.animator.CrossFadeInFixedTime(PlayerPunchHash, CrossFadeDuration);
    }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        normalizedTime = GetNormalizedTime(stateMachine.animator, "Attack");


        if (normalizedTime >= 1f)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }

    }

    public override void Exit() { 
    
    }



}
