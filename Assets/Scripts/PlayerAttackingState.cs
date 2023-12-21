using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerAttackingState : PlayerBaseState
{
    private Attack attack;

    private float previousFrameTime;
    public PlayerAttackingState(PlayerStateMachine stateMachine, int attackIndex) : base(stateMachine)
    {
        attack = stateMachine.Attacks[attackIndex];
    }

    public override void Enter()
    {
        stateMachine.animator.CrossFadeInFixedTime(attack.AnimationName, attack.TransitionDuration);
    }

    public override void Tick(float deltaTime)
    {
        

        float normalizedTime = GetNormalizedTime();

        if(normalizedTime > previousFrameTime && normalizedTime < 1f) {

            if(stateMachine.InputReader.isAttacking)
            {
                TryComboAttack(normalizedTime);
            }
        }

        previousFrameTime = normalizedTime;
    }

    private void TryComboAttack(float normalizedTime)
    {
        if ((attack.ComboStateIndex == -1)){ return; }

        if (normalizedTime < attack.ComboAttackTime) { return; }

        stateMachine.SwitchState
        (

        new PlayerAttackingState
        (
            stateMachine,
            attack.ComboStateIndex
        )
        
        );
    }
      

    public override void Exit()
    {

    }

   

    private float GetNormalizedTime()
    {
       AnimatorStateInfo currentInfo = stateMachine.animator.GetCurrentAnimatorStateInfo(0);
       AnimatorStateInfo nextInfo    = stateMachine.animator.GetCurrentAnimatorStateInfo(0);

        if(stateMachine.animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return nextInfo.normalizedTime;
        }

        else if(stateMachine.animator.IsInTransition(0) && nextInfo.IsTag("Attack"))
        {
            return currentInfo.normalizedTime;
        }

        else
        {
            return 0;
        }

    }

}



