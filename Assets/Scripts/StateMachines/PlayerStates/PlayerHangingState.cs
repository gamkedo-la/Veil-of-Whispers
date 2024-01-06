using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHangingState : PlayerBaseState
{
    private readonly int HangHash = Animator.StringToHash("Hanging");
    private const float CrossFadeDuration = 0.1f;
    private const float AnimatorDampTime = 0.1f;
    private Vector3 closestPoint;
    private Vector3 ledgeForward;
    public PlayerHangingState(PlayerStateMachine stateMachine, Vector3 closestPoint, Vector3 ledgeForward) : base(stateMachine)
    {
        this.closestPoint = closestPoint;
        this.ledgeForward = ledgeForward;
    }

    public override void Enter()
    {
        stateMachine.transform.rotation = Quaternion.LookRotation(ledgeForward, Vector3.up);    
        stateMachine.animator.CrossFadeInFixedTime(HangHash, CrossFadeDuration);

        stateMachine.ledgeDetector.OnLedgeDetect += HandleLedgeDetect;

    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.InputReader.MovementValue.y < 0f)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }
            
    }

    public override void Exit()
    {
        stateMachine.ledgeDetector.OnLedgeDetect -= HandleLedgeDetect;
    }

    private void HandleLedgeDetect(Vector3 closestPoint, Vector3 ledgeForward)
    {
        stateMachine.SwitchState(new PlayerHangingState(stateMachine, closestPoint, ledgeForward));
    }

}
