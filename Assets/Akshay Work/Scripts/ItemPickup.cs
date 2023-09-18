using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemPickup : MonoBehaviour
{
    public UnityEvent onItemPickup; //On Item Pick up Call the PlayerItemManager to pick up the item
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Collided with {other.transform.name} using collider");
        if (other.collider.CompareTag("Player"))
        {
            onItemPickup?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Debug.Log($"Collided with {hit.transform.name} using character controller");
        onItemPickup?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"Collided with {other.transform.name} using Trigger");
        if (other.CompareTag("Player"))
        {
            onItemPickup?.Invoke();
            Destroy(gameObject);
        }
    }
}
