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


        stateMachine.animator.SetFloat(FreeLookSpeedHash, 0f);

        stateMachine.animator.CrossFadeInFixedTime(FreeLookBlendTreeHash, CrossFadeDuration);


    }

    public override void Tick(float deltaTime)
    {

        if (stateMachine.InputReader.isPunchR)
        {
            stateMachine.SwitchState(new PlayerRPunchState(stateMachine));
        }

        if (stateMachine.InputReader.isPunchL)
        {
            stateMachine.SwitchState(new PlayerLPunchState(stateMachine));
        }

        if (stateMachine.InputReader.isKickR)
        {
            stateMachine.SwitchState(new PlayerRKickState(stateMachine));
        }

        if (stateMachine.InputReader.isKickL)
        {
            stateMachine.SwitchState(new PlayerLKickState(stateMachine));
        }

        if (stateMachine.InputReader.isCrouch == true)
        {
            stateMachine.SwitchState(new PlayerCrouchState(stateMachine));
        }

        if(!stateMachine.Controller.isGrounded )
        {
            stateMachine.SwitchState(new PlayerFreeFallState(stateMachine));
        }

      

        Vector3 movement = new Vector3();

        Move(movement * stateMachine.MovementSpeed, deltaTime);



        stateMachine.transform.Rotate(Vector3.up, stateMachine.InputReader.MovementValue.x * 140.0f * deltaTime);

    

        stateMachine.Controller.Move( stateMachine.InputReader.MovementValue.y * stateMachine.transform.forward * stateMachine.MovementSpeed * deltaTime);
        
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
