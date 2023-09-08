public abstract class EnemyState
{
    protected EnemyController enemyController;

    public abstract void OnStateEnter();

    public abstract void OnStateExit();

    public abstract void OnStateUpdate();
}
