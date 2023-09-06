using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerItem : MonoBehaviour
{
    [SerializeField] protected string itemName;
    [SerializeField] protected Sprite itemIcon;

    // This method will be called when the player uses the item.
    public abstract void UseItem(PlayerItemManager player);

    // This method can be used to check if the item can be used.
    public virtual bool CanUseItem(PlayerItemManager player)
    {
        // Implement your logic to check if the player can use the item here.
        // For example, checking if the player has enough resources or is in the right state.
        return true;
    }

    // This method can be used to initialize the item when it is picked up.
    public virtual void InitializeItem(PlayerItemManager player)
    {
        // Implement any initialization logic here.
    }

    // This method can be used to clean up the item when it is removed or depleted.
    public virtual void CleanupItem(PlayerItemManager player)
    {
        // Implement any cleanup logic here.
    }

    // Getter for the item name.
    public string ItemName
    {
        get { return itemName; }
    }

    // Getter for the item icon.
    public Sprite ItemIcon
    {
        get { return itemIcon; }
    }
}
