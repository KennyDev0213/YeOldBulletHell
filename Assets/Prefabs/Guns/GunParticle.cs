using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunParticle : MonoBehaviour
{
    public float lifetime = 0.5f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
