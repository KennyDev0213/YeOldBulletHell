using UnityEngine;

public class EnemyAttackState : EnemyState {
    
    float attackCooldown;

    public EnemyAttackState(EnemyController controller)
    {
        enemyController = controller;
    }

    public override void OnStateEnter()
    {
        attackCooldown = 0;
        enemyController.nav.isStopped = true;
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
    {
        enemyController.transform.LookAt(enemyController.targetTransform.position);

        //if the player leaves the attack range then start following the player again
        if(Vector3.Distance(enemyController.transform.position, enemyController.targetTransform.position) > enemyController.attackRange)
        {
            enemyController.ChangeState(new EnemyWanderState(enemyController));
        }
        else if (attackCooldown <= 0)
        {
            enemyController.weapon.Use();
            attackCooldown = 1 / enemyController.attackRate;
        }
        else {
            attackCooldown -= Time.deltaTime;
        }
        
    }
}