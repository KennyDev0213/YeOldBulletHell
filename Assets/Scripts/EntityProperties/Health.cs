using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health { get; private set; }
    public int maxHealth = 100;
    [SerializeField] public UnityEvent onDeath, onHealthChange;

    string assignedStat;

    protected virtual void Start()
    {
        health = maxHealth;
    }

    public void AddHealth(int amount)
    {
        health += amount;

        if(amount < 0 && assignedStat != null){
            PlayerStatistics.instance.UpdateStat(assignedStat, -amount);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            onDeath?.Invoke();
            return;
        }

        onHealthChange?.Invoke();
    }

    public void SetStatisticEvent(string statistic)
    {
        assignedStat = statistic;
    }
    
}
