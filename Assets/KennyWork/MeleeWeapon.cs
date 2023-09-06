using UnityEngine;

public class MeleeWeapon : Weapon {

    GameObject owner;

    public float range = 1f;

    private void Start() {
        
    }
    
    public override void Use() {
        //TODO att melee functionality
        Debug.Log($"{gameObject.name} is attacking");
    }
}