using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeFallState : PlayerBaseState
{
    private readonly int FreeFallHash = Animator.StringToHash("PlayerFreeFall");
    private const float CrossFadeDuration = 0.1f;

    public PlayerFreeFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }


    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(FreeFallHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {

    }
}
