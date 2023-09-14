using UnityEngine;

public class GunWeapon : Weapon {

    [SerializeField] private GameObject bulletEffect;
    public float range = 10f;
    public Transform gunPoint; 
    
    public override void Start() {
        base.Start();
    }

    public override void Use() {
        weaponAudio.Play();
        weaponAnimator.Play("Shoot");

        RaycastHit hit;
        if (Physics.Raycast(gunPoint.position, gunPoint.forward, out hit, range))
        {
            Instantiate(bulletEffect, hit.point, transform.rotation, hit.transform);

            Health targetHealth = hit.transform.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.AddHealth(-damage);
                //Debug.Log($"delt {damage} to {hit.transform.name}, it's current health is {targetHealth.health}");
            }
        }
    }
}