using UnityEngine;

public class GunWeapon : Weapon {

    GameObject owner;

    public float range = 10f;

    public Transform gunPoint; 
    
    public override void Use() {
        RaycastHit hit;
        if (Physics.Raycast(gunPoint.position, gunPoint.forward, out hit, range))
        {
            Health targetHealth = hit.transform.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.AddHealth(-damage);
            }
        }

        Debug.Log($"{gameObject.name} is attacking");
    }
}