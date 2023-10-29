using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{ 
    public PlayerMovementState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
       
    }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();


        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;
       // stateMachine.transform.Translate(movement * deltaTime);
        stateMachine.Controller.Move(movement * stateMachine.MovementSpeed * deltaTime);

        if (stateMachine.InputReader.MovementValue == Vector2.zero) { return; }

        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
        
    }

    public override void Exit()
    {

    }


}
