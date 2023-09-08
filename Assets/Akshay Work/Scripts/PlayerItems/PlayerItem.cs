using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerItem : MonoBehaviour
{
    public string itemName { get; protected set; }
    public Sprite itemIcon { get; protected set; }

    // Constructor to initialize item properties.
    public PlayerItem(string name, Sprite icon)
    {
        itemName = name;
        itemIcon = icon;
    }

    // Abstract method to describe the item (to be implemented by derived classes).
    public abstract string GetItemDescription();
}
