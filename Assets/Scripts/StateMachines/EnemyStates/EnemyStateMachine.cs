using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyStateMachine : StateMachine
{
    [field: SerializeField] public Animator animator { get; private set; }

    [field: SerializeField] public CharacterController Controller { get; private set; }

   // [field: SerializeField] public ForceReciever ForceReceiver { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }

    [field: SerializeField] public NavMeshAgent Agent { get; private set; }

    [field: SerializeField] public Health Health { get; private set; }

    [field: SerializeField] public float playerChasingRange { get; private set; }

    [field: SerializeField] public float AttackRange { get; private set; }


    public GameObject Player { get; private set; }

    public AudioState state { get; private set; }



    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        state = GetComponent<AudioState>(); 

        Agent.updatePosition = false;
        Agent.updateRotation = false;

        SwitchState(new EnemyIdleState(this));
    }

    private void OnDeawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerChasingRange);
    }

    private void OnEnable()
    {
        Health.OnKickRDamage +=  HandleKickDamage;
        Health.OnKickLDamage +=  HandleKickDamage;
        Health.OnPunchRDamage += HandlePunchRDamage;
        Health.OnPunchLDamage += HandlePunchLDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage += HandleKickDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleKickDamage()
    {
        SwitchState(new EnemyImpactState(this));
        state.PlayerKickSound();
        state.EnemyGrowlSound();

    }

    private void HandlePunchRDamage()
    {
        SwitchState(new EnemyPunchRState(this));
        state.PlayerPunchSound();
        state.EnemyGrowlSound();

    }

    private void HandlePunchLDamage()
    {
        SwitchState(new EnemyPunchLState(this));
        state.PlayerPunchSound();
        state.EnemyGrowlSound();

    }


    private void HandleDie()
    {
        SwitchState(new EnemyDeadState(this));
    }

    public void ControllerVisibility()
    {
        if(Controller.enabled == false)
        {
           SwitchState(new EnemyIdleState(this));
        }
    }

} 
