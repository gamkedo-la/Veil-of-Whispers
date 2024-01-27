using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPunchRState : EnemyBaseState
{
    private readonly int PunchRImpactHash = Animator.StringToHash("EnemyDamagePunchR");

    private const float CrossFadeDuration = 0.1f;

    private float duration = 1f;


    public EnemyPunchRState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(PunchRImpactHash, CrossFadeDuration);

    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        duration -= deltaTime;

        if (duration <= 0f)
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
        }
    }

    public override void Exit()
    {

    }


}
