using System.Collections.Generic;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    public static PlayerItemManager instance;

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
    private int count = 0;
    private List<string> playerInventory = new List<string>();
    [SerializeField] private List<Transform> spawnPostions;
    [SerializeField] private List<GameObject> player_Items;
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
            //spawnPostions.RemoveAt(randomIndex);
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

    // Start is called before the first frame update
    void Start()
    {
        DisplayPlayerItems();
        SpawnItems();
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count == 3000)
        {
            //RemoveSpawnItems();
            SpawnItems();
            count = 0;
        }
    }
}
