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
    public NavMeshAgent nav;
    public EnemyState currentState;
    public Transform playerTransform;
    public float attackRange = 1f, attackRate = 1f;

    public Weapon weapon;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        currentState = new EnemyAttackState(this);    
    }

    //implementation of the state machine
    public void ChangeState(EnemyState state)
    {
        currentState.OnStateExit();
        currentState = state;
        currentState.OnStateEnter();
    }

    public void OnDeath()
    {
        ChangeState(new EnemyDeadState(this));
    }

    void Update()
    {
        currentState.OnStateUpdate();
    }
}
