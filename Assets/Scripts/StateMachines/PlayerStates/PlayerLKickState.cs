using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLKickState : PlayerBaseState
{
    private readonly int PlayerKickHash = Animator.StringToHash("PlayerKickRight");
    private const float CrossFadeDuration = 1f;
    public PlayerLKickState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        stateMachine.animator.CrossFadeInFixedTime(PlayerKickHash, CrossFadeDuration);
    }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {

        if (!stateMachine.InputReader.isKickL)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }

    }

    public override void Exit()
    {

    }
}

