using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private readonly int EnemyBlendTreeHash = Animator.StringToHash("EnemyBlend");
    private readonly int MoveHash = Animator.StringToHash("move");


    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(EnemyBlendTreeHash, CrossFadeDuration);
    }

   

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if (IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
            return;
        }

        FacePlayer();

        stateMachine.animator.SetFloat(MoveHash, 0f, AnimatorDampTime, deltaTime);
    }

    public override void Exit() { }


}
