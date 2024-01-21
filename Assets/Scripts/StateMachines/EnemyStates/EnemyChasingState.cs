using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyChasingState : EnemyBaseState
{
    private readonly int EnemyBlendTreeHash = Animator.StringToHash("EnemyBlend");
    private readonly int MoveHash = Animator.StringToHash("move");
    private AudioState audioState;


    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;

    public EnemyChasingState(EnemyStateMachine stateMachine) : base(stateMachine) {  }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(EnemyBlendTreeHash, CrossFadeDuration);
        audioState = stateMachine.GetComponent<AudioState>();
    }

    public override void Tick(float deltaTime)
    {
        if (!IsInChaseRange())
        {
            audioState.StopFootStepSound();
            stateMachine.SwitchState(new EnemyIdleState(stateMachine));
            return;
        }

        if(IsInAttackRange() && ControllerVisibility()) {
            stateMachine.SwitchState(new EnemyAttackingState(stateMachine));
            return;
        }

        audioState.PlayFootStepSound();

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
       /*if(flatDesired.y > 0f)
        {
            flatDesired.y = 0f;
       }*/

        Move(flatDesired.normalized * stateMachine.MovementSpeed, deltaTime);
        Vector3 flatVelocity = stateMachine.Controller.velocity;

      /*  if (flatVelocity.y > 0f)
        {
            flatVelocity.y = 0f;
        }*/


        stateMachine.Agent.velocity = flatVelocity;
    }

   

}
