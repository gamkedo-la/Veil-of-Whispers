using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field : SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public CharacterController Enemycontroller { get; private set; }
    [field: SerializeField] public ForceReciever ForceReceiver { get; private set; }
    [field: SerializeField] public Animator animator { get; private set; }

    [field: SerializeField] public Targeter Targeter { get; private set; }

    [field: SerializeField] public Health Health { get; private set; }

    [field: SerializeField] public GroundCheck GroundCheck { get; private set; }

    [field: SerializeField] public LedgeDetector ledgeDetector { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }

    [field: SerializeField] public float JumpForce { get; private set; }

    [field: SerializeField] public Collider PlayerCollider { get; private set; }


    [field: SerializeField] public Attack[] Attacks { get; private set; }


    public Transform MainCameraTransform { get; private set; }

    public AudioState state { get; private set; }



    bool alreadyDied = false;


    void Start()
    {
        MainCameraTransform = Camera.main.transform;
        state = GetComponent<AudioState>();
        SwitchState(new PlayerFreeLookState(this)); 
    }

    private void OnEnable ()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
        GroundCheck.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
        GroundCheck.OnDie -= HandleDie;

    }

    private void HandleTakeDamage()
    {
        SwitchState(new PlayerImpactState(this));
        state.EnemyAttackSound();
    }


    private void HandleDie()
    {
        if (alreadyDied)
        {
            return;
        }

        alreadyDied = true;

        SwitchState(new PlayerDeadState(this));
        state.PlayerDieSound();
        PlayerRagDoll();
    }

    private void PlayerRagDoll()
    {
        Controller.enabled = false;
    }

}
