using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {
    [SerializeField] UnityEvent collisionEvent;
    [SerializeField] GameObject collisionEffect;
    public float lifetime = 100f, blastRadius = 1f;
    private float effectTime = 3f;
    public int damage = 1;

    private void Start() {
        Destroy(gameObject, lifetime);
    }

    public void ChangeVelocity(Vector3 velocity, float speed)
    {
        transform.GetComponent<Rigidbody>().AddForce(velocity * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other) {
        collisionEvent?.Invoke();
        
        if(collisionEffect != null)
        {
            GameObject effect = Instantiate(collisionEffect, transform.position, Quaternion.identity);
            Destroy(effect, effectTime);
        }

        Destroy(gameObject);
    }

    public void DoDamage()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, blastRadius, transform.forward);
        foreach (RaycastHit hit in hits)
        {
            Health objectHealth = hit.transform.GetComponent<Health>();

            if(objectHealth != null)
            {
                objectHealth.AddHealth(-damage);
            }
        }
    }
}