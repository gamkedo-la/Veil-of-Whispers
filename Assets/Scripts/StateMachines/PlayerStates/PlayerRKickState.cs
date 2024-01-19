using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRKickState : PlayerBaseState
{
    private readonly int PlayerKickRHash = Animator.StringToHash("PlayerKickRight");
    private const float CrossFadeDuration = 1f;
    float normalizedTime;
    public PlayerRKickState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        stateMachine.animator.CrossFadeInFixedTime(PlayerKickRHash, CrossFadeDuration);
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

    public override void Exit()
    {

    }
}

