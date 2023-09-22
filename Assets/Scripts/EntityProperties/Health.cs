using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health { get; private set; }
    //[SerializeField] GameObject Player;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public UnityEvent onDeath;
    AttributeManager attributeManager;
    private float maxHealthMultiplyer = 0;

    void Start()
    {
        attributeManager = AttributeManager.instance;
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

    public void SetMaxHealth()
    {
        //Player.GetComponent<Health>().health = maxHealth + (int)maxHealthMultiplyer;
    }

    public void Update()
    {
        maxHealthMultiplyer = attributeManager.GetAttribute("player_maxhealth_multiplier");
    }
}
