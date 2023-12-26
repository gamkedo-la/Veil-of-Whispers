using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpHash = Animator.StringToHash("PlayerJump");

    private Vector3 momentum;

    private const float CrossFadeDuration = 0.1f;
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
       // stateMachine.ForceReceiver.Jump(stateMachine.JumpForce);
        stateMachine.animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);
        momentum = stateMachine.Controller.velocity;
        momentum.y = 0f;
    }

    public override void Tick(float deltaTime)
    {
       if(stateMachine.Controller.velocity.y < 0f)
       {
          stateMachine.SwitchState(new PlayerFallState(stateMachine));
       }
    }

    public override void Exit()
    {

    }

}
