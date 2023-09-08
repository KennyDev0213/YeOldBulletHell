using UnityEngine;

public class EnemyIdleState : EnemyState {
    
    public EnemyIdleState(EnemyController controller)
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
        //TODO
        //if enemy gets a line of site to the player then go into EnemyWanderState    
    }
}