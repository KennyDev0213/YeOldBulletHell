using UnityEngine;

public class EnemyWanderState : EnemyState {
    
    public EnemyWanderState(EnemyController controller)
    {
        enemyController = controller;
    }

    public override void OnStateEnter()
    {
        Debug.Log($"{enemyController.name} is now wondering");
        enemyController.enemyAnimator.SetBool("isWalking", true);
    }

    public override void OnStateExit()
    {
        enemyController.enemyAnimator.SetBool("isWalking", false);
    }

    public override void OnStateUpdate()
    {
        //if the enemy is close enough to the player then change into an attack state
        if(Vector3.Distance(enemyController.transform.position, enemyController.targetTransform.position) <= enemyController.attackRange)
        {
            enemyController.ChangeState(new EnemyAttackState(enemyController));
        }

        //otherwise move towards the player
        else if(enemyController.nav.isOnNavMesh)
        {
            enemyController.nav.SetDestination(enemyController.targetTransform.position);
        }

        else
        {
            enemyController.ChangeState(new EnemyIdleState(enemyController));
        }
    }
}