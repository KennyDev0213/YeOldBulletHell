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
    }

    public override void OnStateExit()
    {
        
    }

    public override void OnStateUpdate()
    {
        
    }
}