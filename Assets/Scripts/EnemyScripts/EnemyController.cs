using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//<Summery>
//this is the controller for enemy instances, needs to be attached to prefab like a monobehaviour
//</Summery>
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent nav;
    public EnemyState currentState;
    public Transform targetTransform;
    public float attackRange = 1f, attackRate = 1f;

    public int scoreValue = 0;

    public Weapon weapon;

    [HideInInspector] public Animator enemyAnimator;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();

        if(targetTransform == null)
        {
            currentState = new EnemyIdleState(this);
            Debug.LogWarning($"{name} has no target transform set, make sure it is assigned in the inspector");
        }
        else {
            currentState = new EnemyWanderState(this);
        }

        currentState.OnStateEnter();
    }

    //implementation of the state machine
    public void ChangeState(EnemyState state)
    {
        currentState.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }

    //on death used in the Health script attached to this gameObject as the onDeath event
    public void OnDeath()
    {
        ChangeState(new EnemyDeadState(this));
    }

    //used for animation events
    public void UseWeapon()
    {
        weapon.Use();
    }

    void Update()
    {
        currentState.OnStateUpdate();
    }
}
