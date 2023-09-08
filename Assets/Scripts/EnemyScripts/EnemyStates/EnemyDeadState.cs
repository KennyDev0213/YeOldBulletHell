using UnityEngine;

public class EnemyDeadState : EnemyState {
    
    public EnemyDeadState(EnemyController controller)
    {
        enemyController = controller;
    }

    public override void OnStateEnter()
    {
        //TODO 
        // - add onDeath animation
        // - add body lifetime before Destroying the object (for performance)

        enemyController.enemyAnimator.SetBool("isDead", true);
        enemyController.nav.enabled = false;
    }

    public override void OnStateExit()
    {
        enemyController.enemyAnimator.SetBool("isDead", false);
    }

    public override void OnStateUpdate()
    {
        
    }
}