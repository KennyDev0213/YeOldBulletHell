using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunControl : MonoBehaviour
{
    public float attackRate = 1f;
    private float attackCooldown = 0f;
    PlayerInput playerInput;

    [SerializeField] private Weapon currentWeapon;

    void Start()
    {
        if(playerInput == null){
            playerInput = PlayerInput.GetInstance();
        }        
    }

    void Update()
    {
        if(attackCooldown > 0)
            attackCooldown -= Time.deltaTime;

        if(playerInput.m1){
            if(attackCooldown > 0) return;

            Debug.Log("Player Shot!");

            currentWeapon.Use();

            attackCooldown = 1 / attackRate;
        }
    }
}
