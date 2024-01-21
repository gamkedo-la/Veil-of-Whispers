using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLKickState : PlayerBaseState
{
    private readonly int PlayerKickLHash = Animator.StringToHash("PlayerKickLeft");
    private const float CrossFadeDuration = 0.5f;
    float normalizedTime;
    public PlayerLKickState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        stateMachine.animator.CrossFadeInFixedTime(PlayerKickLHash, CrossFadeDuration);
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

