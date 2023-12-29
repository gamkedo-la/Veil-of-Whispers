using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field : SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReciever ForceReceiver { get; private set; }
    [field: SerializeField] public Animator animator { get; private set; }

    [field: SerializeField] public Targeter Targeter { get; private set; }


    [field: SerializeField] public float MovementSpeed { get; private set; }

    [field: SerializeField] public float JumpForce { get; private set; }


    [field: SerializeField] public Attack[] Attacks { get; private set; }


    public Transform MainCameraTransform { get; private set; }




    void Start()
    {
        MainCameraTransform = Camera.main.transform;
        SwitchState(new PlayerFreeLookState(this)); 
    }


}
