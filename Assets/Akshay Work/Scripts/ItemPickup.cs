using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour
{
    public UnityEvent onItemPickup; //On Item Pick up Call the PlayerItemManager to pick up the item
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onItemPickup?.Invoke();
            Destroy(gameObject);
        }
    }
}
