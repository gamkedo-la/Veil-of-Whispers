using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {

        if (stateMachine.InputReader.isAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine,1));
        }
        Vector3 movement = new Vector3();

        stateMachine.transform.Rotate(Vector3.up, stateMachine.InputReader.MovementValue.x * 140.0f * deltaTime);

    

        // multiplying by negative one so forward goes the expected direction
        stateMachine.Controller.Move( -1.0f*stateMachine.InputReader.MovementValue.y * stateMachine.transform.forward * stateMachine.MovementSpeed * deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {

            stateMachine.animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);
            return;
        }

        stateMachine.animator.SetFloat("FreeLookSpeed", 1, 0.1f, deltaTime);
        //stateMachine.transform.rotation = Quaternion.LookRotation(movement);
    }


    public override void Exit()
    {

    }

}
