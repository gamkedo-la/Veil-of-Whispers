using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeFallState : PlayerBaseState
{
    private readonly int FreeFallHash = Animator.StringToHash("PlayerFreeFall");
    private const float CrossFadeDuration = 0.1f;

    public PlayerFreeFallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        
    }


    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(FreeFallHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();



        Move(movement.normalized * stateMachine.MovementSpeed, deltaTime);

        stateMachine.transform.Rotate(Vector3.up, stateMachine.InputReader.MovementValue.x * 140.0f * deltaTime);

        stateMachine.Controller.Move(stateMachine.InputReader.MovementValue.y * stateMachine.transform.forward * stateMachine.MovementSpeed * deltaTime);
    }

    public override void Exit()
    {

    }
}
