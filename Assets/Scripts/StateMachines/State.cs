using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    public abstract void Enter();

    public abstract void Tick(float deltaTime);

    public abstract void Exit();

    protected float GetNormalizedTime(Animator animator, string stateName = "Attack")
    {
       AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
       AnimatorStateInfo nextInfo    = animator.GetCurrentAnimatorStateInfo(0);

        if(animator.IsInTransition(0) && nextInfo.IsTag(stateName))
        {
            return nextInfo.normalizedTime;
        }

        else if(animator.IsInTransition(0) && nextInfo.IsTag(stateName))
        {
            return currentInfo.normalizedTime;
        }

        else
        {
            return 0;
        }

    }

}