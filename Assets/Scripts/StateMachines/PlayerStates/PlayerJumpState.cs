using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpHash = Animator.StringToHash("PlayerJump");
    private Vector3 momentum;
      



    private const float CrossFadeDuration = 1f;
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.ForceReceiver.Jump(stateMachine.JumpForce);
        stateMachine.animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);
        momentum = stateMachine.Controller.velocity;
        audioState.JumpSound();

    }

    public override void Tick(float deltaTime)
    {
        Move(momentum, deltaTime);

       if(stateMachine.Controller.velocity.y <= 0f)
       {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
          return;
       }
    }

    public override void Exit()
    {
    }

}
