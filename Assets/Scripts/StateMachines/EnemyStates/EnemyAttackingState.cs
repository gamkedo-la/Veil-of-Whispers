using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState : EnemyBaseState
{
    private readonly int AttackHash = Animator.StringToHash("EnemyAttack");

    private const float TransitionDuration = 0.1f;
    public EnemyAttackingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (!IsInAttackRange() )
        {
            stateMachine.SwitchState(new EnemyChasingState(stateMachine));
            return;
        }

        if(!ControllerVisibility())
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
        }



        FacePlayer();

    }

    public override void Exit()
    {

    }




}
