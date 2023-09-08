using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : PlayerItem
{
    [SerializeField] string WeaponName;
    public int damage { get; private set; }


    // Constructor to initialize weapon-specific properties.
    public WeaponItem(string name, Sprite icon, int damage) : base(name, icon)
    {
        WeaponName = name;
        this.damage = damage;
    }

    // Implement the abstract method to describe the weapon.
    public override string GetItemDescription()
    {
        return "Weapon: " + itemName + "\nDamage: " + damage;
    }
}
