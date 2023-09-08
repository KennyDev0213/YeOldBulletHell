using UnityEngine;

public class MeleeWeapon : Weapon {

    GameObject owner;

    public float range = 1f;

    public override void Start() {
        base.Start();
    }
    
    public override void Use() {
        RaycastHit[] raycastHits = Physics.SphereCastAll(transform.position, range, transform.forward);
        foreach (RaycastHit hit in raycastHits) {

            Health targetHealth = hit.transform.GetComponent<Health>();

            if(targetHealth != null) 
            {
                targetHealth.AddHealth(-damage);
            }
        }

        //Debug.Log($"{gameObject.name} is attacking");
    }
}