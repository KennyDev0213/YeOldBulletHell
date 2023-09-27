using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerHealth : Health
{
    AttributeManager attributeManager;
    PauseMenu pauseMenu;
    public float maxHealthMultiplyer = 0;
    public int Count = 0;

    protected void Awake()
    {
        attributeManager = AttributeManager.instance;

        if (attributeManager == null)
        {
            Debug.LogWarning("AttributeManager.instance is not properly initialized. PlayerHealth");
        }
    }
    protected override void Start()
    {
        base.Start(); // Call the base class Start method if you override it.
    }
    public void MaxHealthUp()
    {
        maxHealth += (int)maxHealthMultiplyer;
    }
    public void Update()
    {
        if (attributeManager.GetAttribute("player_maxhealth_multiplier") > maxHealthMultiplyer)
        {
            maxHealthMultiplyer = attributeManager.GetAttribute("player_maxhealth_multiplier");
            maxHealth *= (int)maxHealthMultiplyer;
        }

        if (health < maxHealth && Time.timeScale == 1)
        {
            Count++;
            if(Count == 1000)
            {
                AddHealth(1 * (int)attributeManager.GetAttribute("player_healthregen_multiplier"));
                Count = 0;
            }
        }
    }

}
