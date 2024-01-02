using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargettingState : PlayerBaseState
{
    public PlayerTargettingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        //stateMachine.InputReader.JumpEvent += OnJump;
    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.InputReader.isAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine,0));
            return;
        }
    }

    private void OnJump()
    {
       // stateMachine.SwitchState(new PlayerJumpState(stateMachine,3));
    }

    public override void Exit()
    {
       // stateMachine.InputReader.JumpEvent -= OnJump;
    }

}
