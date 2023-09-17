using UnityEngine;

public class ProjectileWeapon : Weapon {

    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform gunPoint;

    public float projectileSpeed = 1f;

    private void Awake() {
        if(projectile == null || projectile.GetComponent<Projectile>() == null)
        {
            Debug.LogError($"{name} needs a GameObject with a 'projectile' script or 'projectile' inherited class attached, {projectile.name} has so such script");
        }
    }

    public override void Start() {
        base.Start();
    }
    
    public override void Use() {
        
        weaponAudio?.Play();

        GameObject tempProjectile = Instantiate(projectile, gunPoint.position, gunPoint.rotation);
        Vector3 dir = Vector3.Normalize(gunPoint.rotation.eulerAngles);
        dir += gunPoint.forward * projectileSpeed;
        tempProjectile.GetComponent<Projectile>().ChangeVelocity(dir, projectileSpeed);

        //ROCKET LAUNCHER is not accurate when firing, need fix
    }
}