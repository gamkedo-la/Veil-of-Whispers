using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(float deltaTime)
    {
       Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move(motion* deltaTime);
    }

    protected void FacePlayer()
    {
        if (stateMachine.Controller == null) { return; }

        Vector3 lookPos = stateMachine.Player.transform.position - stateMachine.transform.position;
        lookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(-lookPos);
    }

    protected bool IsInChaseRange()
    {
       float playerDistance =  (stateMachine.Player.transform.position - stateMachine.transform.position).magnitude;
       return playerDistance <= stateMachine.playerChasingRange;
    }

    protected bool IsInAttackRange()
    {
        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.AttackRange * stateMachine.AttackRange;
    }

    protected bool ControllerVisibility()
    {
        CharacterController controller = stateMachine.Player.GetComponent<CharacterController>();
        return controller.enabled;
    }
}
