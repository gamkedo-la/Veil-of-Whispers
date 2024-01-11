using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private readonly int DeadHash = Animator.StringToHash("PlayerDie");
    private const float CrossFadeDuration = 0.1f;

    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(DeadHash, CrossFadeDuration);
        stateMachine.PlayerCollider.enabled = false;
        stateMachine.Enemycontroller.enabled = false;
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {

    }

  
}
