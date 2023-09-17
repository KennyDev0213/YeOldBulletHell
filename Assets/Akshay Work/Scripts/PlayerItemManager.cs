using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    private List<string> playerInventory = new List<string>();
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

    public void SpawnItem()
    {
        //Spawns an Item in a spot on the map.

        Debug.Log("Item has Spawned");
    }

    // Start is called before the first frame update
    void Start()
    {
        DisplayPlayerItems();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
