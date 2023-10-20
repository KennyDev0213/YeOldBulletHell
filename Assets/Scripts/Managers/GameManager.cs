using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Object")]
    [SerializeField] private GameObject player;
    [Header("What enemies to spawn in this stage")]
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] bosses;
    [Header("where enemies can spawn (subject to change)")]
    private Transform[] spawnPoints; //temporary until we figure out how to implement this

    public static GameManager instance {private set; get;}
    [Header("how many enemies will be allowed on the level at once")]
    public int maxEnemies = 10;
    private int enemyNumber = 0;
    private float spawnInterval = 10, timeSinceLastSpawn = 0;
    private bool isPlaying = true;
    public int playerScore {get; private set;}

    private Queue<GameObject> enemyBodies = new Queue<GameObject>();

    PlayerStatistics playerStatistics;

    //PlayerItemManager playerItemManager;

    private void Awake() {
        if (instance != null && instance != this) Destroy(gameObject); else instance = this;
        playerScore = 0;

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        //playerItemManager = PlayerItemManager.instance;
        playerStatistics = PlayerStatistics.instance;

        player.GetComponent<Health>().onDeath.AddListener(OnPlayerDeath);

        player.GetComponent<Health>().SetStatisticEvent("Damage Taken");

        ResetSpawnPoints();
    }

    void FixedUpdate()
    {
        if(!isPlaying) return;

        if(timeSinceLastSpawn <= 0 && enemyNumber < maxEnemies)
        {
            SpawnEnemy();
            timeSinceLastSpawn = spawnInterval;
        }

        if(timeSinceLastSpawn > 0){
            timeSinceLastSpawn -= Time.deltaTime;
        }

        playerStatistics.UpdateStat("Time Alive", Time.deltaTime);
    }

    void DecreaseEnemyCount(){
        playerStatistics.UpdateStat("Enemies Neutralized", 1);
        enemyNumber--;
    }

    public void ResetSpawnPoints()
    {
        GameObject spawnPointHolder = GameObject.Find("EnemySpawnPoints");

        if (spawnPointHolder == null)
        {
            Debug.LogWarning("Could not find 'EnemySpawnPoints' gameobject in scene");
            return;
        }

        List<Transform> sp = new List<Transform>();

        foreach(Transform spawnPoint in spawnPointHolder.transform)
        {
            sp.Add(spawnPoint);
        }

        spawnPoints = sp.ToArray();
    }

    void SpawnEnemy()
    {
        //if enemy array or spawnpoint array are empty return
        if(enemies.Length == 0 || spawnPoints.Length == 0) return;

        //get random enemy type
        int enemyIndex = Random.Range(0, enemies.Length);
        GameObject enemy = enemies[enemyIndex];

        //get random spawn location
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        //instantiate the enemy and assign it the player as a target and initialize needed unity events for game flow
        GameObject newEnemy = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        EnemyController newEnemyController = newEnemy.GetComponent<EnemyController>();
        if(newEnemyController == null)
        {
            Debug.LogWarning($"{newEnemy.name} has no EnemyController script attached to it");
        }
        else{
            newEnemyController.targetTransform = player.transform;
        }

        
        if(newEnemy.GetComponent<Health>() != null)
        {
            Health newEnemyHealth = newEnemy.GetComponent<Health>();
            newEnemyHealth.onDeath.AddListener(DecreaseEnemyCount); //decreases the enemy count so the game manager can keep an accurate tally of enemies
             
            newEnemyHealth.SetStatisticEvent("Damage Dealt");

            //roll on whether the enemy will spawn an item on death or not
            /*
            int itemSpawnRoll = Random.Range(0, 100);
            if(itemSpawnRoll <= ItemSpawnRatePercentage)
            {   
                newEnemy.GetComponent<Health>().onDeath.AddListener(playerItemManager.SpawnItems);
            }
            */
        }

        //add game object to queue
        enemyBodies.Enqueue(newEnemy);

        if (enemyBodies.Count > enemyNumber)
        {
            //remove the first body added for performance
            Destroy(enemyBodies.Dequeue());
        }

        //increase the enemy number
        enemyNumber++;
    }

    public void AddScore(int amount)
    {
        playerScore += amount;
    }

    [SerializeField] GameObject endGamePanel;

    void OnPlayerDeath()
    {
        if(!isPlaying) return;

        foreach(GameObject enemy in enemyBodies)
        {
            Destroy(enemy);
        }

        isPlaying = false;
        PlayerInput.instance.fixPlayerInput = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        endGamePanel.SetActive(true);
        endGamePanel.GetComponent<GameOverUI>().UpdateScore(playerScore.ToString());
        endGamePanel.GetComponent<GameOverUI>().UpdateStatistics();
    }
}