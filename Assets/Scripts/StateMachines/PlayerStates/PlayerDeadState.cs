using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    private readonly int DeadHash = Animator.StringToHash("PlayerDie");
    private const float CrossFadeDuration = 0.1f;
    private bool isDead = false;

    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(DeadHash, CrossFadeDuration);
   
    }

    public override void Tick(float deltaTime)
    {
        isDead = true;
    }

    public override void Exit()
    {

    }

    public bool GetDeadState()
    {
        return isDead;
    }

}
