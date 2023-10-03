using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : PlayerHealth
{
    public void OnPickup()
    {
        AddHealth(50);
        Debug.Log("Player has healed!");
    }
}
