using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyChasingState : EnemyBaseState
{
    private readonly int EnemyBlendTreeHash = Animator.StringToHash("EnemyBlend");
    private readonly int MoveHash = Animator.StringToHash("move");


    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) {  }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(EnemyBlendTreeHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        if (!IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            return;
        }

        if(IsInAttackRange()) {
            stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
            return;
        }


        MoveToPlayer(deltaTime);

        RaycastHit raycast;
        if (Physics.Raycast(stateMachine.transform.position,Vector3.down,out raycast))
        {
            stateMachine.transform.position = raycast.point + Vector3.up * 6f;
        }

        FacePlayer();
        stateMachine.animator.SetFloat(MoveHash, 1f, AnimatorDampTime, deltaTime);


    }

    public override void Exit()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }

    private void MoveToPlayer(float deltaTime)
    {

        stateMachine.Agent.destination = stateMachine.Player.transform.position;
        Vector3 flatDesired = stateMachine.Agent.desiredVelocity.normalized;

        Move(flatDesired.normalized * stateMachine.MovementSpeed, deltaTime);
        Vector3 flatVelocity = stateMachine.Controller.velocity;



        stateMachine.Agent.velocity = flatVelocity;
    }

   

}
