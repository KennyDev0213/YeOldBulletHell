using UnityEngine;

public class MeleeWeapon : Weapon {

    [SerializeField] GameObject owner;

    public float range = 1f;

    public override void Start() {
        base.Start();
    }
    
    public override void Use() {

        weaponAudio?.Play();

        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, range, transform.forward);
        foreach (RaycastHit hit in raycastHits) {

            if (hit.transform.gameObject == owner) continue; //prevents the user from damaging itself

            //if the object has a health script attached then deduct health from it
            Health targetHealth = hit.transform.GetComponent<Health>();
            if(targetHealth != null) 
            {
                targetHealth.AddHealth(-damage);
                Debug.Log($"{name} hit {hit.transform.name} with melee for {damage} damage");
            }
        }
    }
}