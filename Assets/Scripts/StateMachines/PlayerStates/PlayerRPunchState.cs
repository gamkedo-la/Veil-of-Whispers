using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRPunchState : PlayerBaseState
{
    private readonly int PlayerPunchHash = Animator.StringToHash("PlayerPunchRight");
    private const float CrossFadeDuration = 1f;
    public PlayerRPunchState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        stateMachine.animator.CrossFadeInFixedTime(PlayerPunchHash, CrossFadeDuration);
    }

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.animator, "Attack");
        Debug.Log(normalizedTime);

        if (normalizedTime >= 1f)
        {
            stateMachine.InputReader.isPunchR = false;
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            Debug.Log("works");
        }

    }

    public override void Exit()
    {

    }



}
