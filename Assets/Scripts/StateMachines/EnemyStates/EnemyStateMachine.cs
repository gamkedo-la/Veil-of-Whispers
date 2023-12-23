using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator animator { get; private set; }

    private void Start()
    {
        SwitchState(new EnemyIdleState(this));
    }
}
