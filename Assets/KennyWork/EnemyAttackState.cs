using UnityEngine;

public class EnemyAttackState : EnemyState {
    
    public EnemyAttackState(EnemyController controller)
    {
        enemyController = controller;
    }

    public override void OnStateEnter()
    {
        
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
    {
        //if the player leaves the attack range then start following the player again
        if(Vector3.Distance(enemyController.transform.position, enemyController.playerTransform.position) > enemyController.attackRange)
        {
            enemyController.ChangeState(new EnemyWanderState(enemyController));
        }
    }
}