using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class PowerUpItem : PlayerItem
{
    [SerializeField] public float _damage;
    [SerializeField] public float _attackspeed;
    [SerializeField] public float _movespeed;
    [SerializeField] public float _maxhealth;
    [SerializeField] public float _healthregen;
    Health Health;
    AttributeManager attributeManager;

    private void Start()
    {
        attributeManager = AttributeManager.instance;
    }
    public override void OnPickup()
    {
        attributeManager.AddToAttribute("player_damage_multiplier", _damage);
        attributeManager.AddToAttribute("player_movespeed_multiplier", _movespeed);
        attributeManager.AddToAttribute("player_maxhealth_multiplier", _maxhealth);
        attributeManager.AddToAttribute("player_healthregen_multiplier", _healthregen);
        attributeManager.AddToAttribute("player_attackspeed_multiplier", _attackspeed);
        Debug.Log("Powerup Pickedup!");
    }

    public override void ItemActivation()
    {
        Debug.Log("Powerup Is now being used");
    }

    public override void ItemDestory()
    {
        base.ItemDestory();
    }
}
