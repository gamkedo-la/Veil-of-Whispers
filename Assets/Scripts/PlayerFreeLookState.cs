using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;






    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;

        stateMachine.animator.CrossFadeInFixedTime(FreeLookBlendTreeHash, CrossFadeDuration);


    }

    public override void Tick(float deltaTime)
    {

        if (stateMachine.InputReader.isAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine,1));
        }
        Vector3 movement = new Vector3();

        Move(movement * stateMachine.MovementSpeed, deltaTime);



        stateMachine.transform.Rotate(Vector3.up, stateMachine.InputReader.MovementValue.x * 140.0f * deltaTime);

    

        stateMachine.Controller.Move( -1.0f*stateMachine.InputReader.MovementValue.y * stateMachine.transform.forward * stateMachine.MovementSpeed * deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {

            stateMachine.animator.SetFloat("FreeLookSpeed", 0, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.animator.SetFloat("FreeLookSpeed", 1, AnimatorDampTime, deltaTime);
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine));
    }


    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
    }

}
