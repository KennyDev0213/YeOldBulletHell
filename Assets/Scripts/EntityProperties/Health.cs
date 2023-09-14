using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health { get; private set; }
    [SerializeField] int maxHealth = 100;
    [SerializeField] public UnityEvent onDeath;
    
    void Start()
    {
        health = maxHealth;
    }

    public void AddHealth(int amount)
    {
        health += amount;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            onDeath?.Invoke();
        }
    }
}
