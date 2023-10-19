using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    public static PlayerItemManager instance;
    [HideInInspector] public GameManager gameManager;

    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    [SerializeField] private int count = 0;
    private int SpawnBuffer = 5;
    private List<string> playerInventory = new List<string>();
    [SerializeField] private List<Transform> spawnPostions;
    [SerializeField] private List<GameObject> player_Items;
    [SerializeField] private List<GameObject> spawnAble_Items;
    private void DisplayPlayerItems()
    {
        //Keeps track of the players Items
        Debug.Log("Inventory:");
        foreach (string item in playerInventory)
        {
            Debug.Log("- " + item);
        }
    }


    // Function to add an item to the inventory.
    public void AddItem(string item)
    {
        playerInventory.Add(item);
        Debug.Log("Added " + item + " to the inventory.");
        DisplayPlayerItems();

    }

    // Function to remove an item from the inventory.
    public void RemoveItem(string item)
    {
        if (playerInventory.Contains(item))
        {
            playerInventory.Remove(item);
            Debug.Log("Removed " + item + " from the inventory.");
        }
        else
        {
            Debug.LogWarning(item + " not found in the inventory.");
        }
    }

    public bool HasItem(string item)
    {
        return playerInventory.Contains(item);
    }

    public void SpawnItems()
    {
        //Spawns an Item in a spot on the map.
        ShuffleList(spawnPostions);
        for (int i = 0; i < player_Items.Count; i++)
        {
            int randomIndex = Random.Range(0, spawnPostions.Count);
            Transform spawnPosition = spawnPostions[randomIndex];
            Instantiate(player_Items[i], spawnPosition.position, spawnPosition.rotation);

            // Remove the used spawn position to prevent spawning multiple objects in the same place
            spawnPostions.RemoveAt(randomIndex);
        }
        Debug.Log("Item has Spawned");
    }

    private void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = 0; i < n; i++)
        {
            int r = i + Random.Range(0, n - i);
            T temp = list[i];
            list[i] = list[r];
            list[r] = temp;
        }
    }

    public void InASpawnItem()
    {
        //Spawns an Item in a spot on the map.
        ShuffleList(spawnPostions);
        int randomIndexSpawnPosition = Random.Range(0, spawnPostions.Count);
        int randomPlayerSpawnPosition = Random.Range(0, spawnAble_Items.Count);
        Transform spawnPosition = spawnPostions[randomIndexSpawnPosition];
        Instantiate(spawnAble_Items[randomPlayerSpawnPosition], spawnPosition.position, spawnPosition.rotation);

        Debug.Log("A new Item has been spawned in");
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        DisplayPlayerItems();
        SpawnItems();
    }

    // Update is called once per frame
    void Update()
    {
        count = gameManager.playerScore;
        if(count >= SpawnBuffer)
        {
            //RemoveSpawnItems();
            InASpawnItem();
            if(count < 20)
            {
              SpawnBuffer += 5;
            }
            
            if (count > 50)
            {
                SpawnBuffer *= 2; 
            }
        }
    }
}
