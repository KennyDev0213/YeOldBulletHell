using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunControl : MonoBehaviour
{
    AttributeManager attributeManager;
    public float attackRate = 1f;
    private float attackCooldown = 0f, attackRateMultiplier = 1f;
    PlayerInput playerInput;

    [SerializeField] private Weapon currentWeapon;

    void Start()
    {
        if(playerInput == null){
            playerInput = PlayerInput.GetInstance();
        }

        attributeManager  = AttributeManager.instance;

        UpdateAttributes();
    }

    void Update()
    {
        if(attackCooldown > 0)
            attackCooldown -= Time.deltaTime;

        if(playerInput.m1){
            if(attackCooldown > 0) return;

            currentWeapon.Use();

            attackCooldown = 1 / (attackRate * attackRateMultiplier);
        }
    }

    private void FixedUpdate() {
        UpdateAttributes();
    }

    void UpdateAttributes()
    {
        attackRateMultiplier = attributeManager.GetAttribute("player_attackspeed_multiplier");
    }
}
