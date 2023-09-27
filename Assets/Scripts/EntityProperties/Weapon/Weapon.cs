using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Animator))]
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected AudioSource weaponAudio;
    [SerializeField] protected Animator weaponAnimator;

    public virtual void Start(){
        weaponAudio = GetComponent<AudioSource>();
        weaponAnimator = GetComponent<Animator>();
    } 

    public int damage;

    public abstract void Use();
}
