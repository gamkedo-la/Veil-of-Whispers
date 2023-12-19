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

    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.InputReader.isAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {

    }
    
}
