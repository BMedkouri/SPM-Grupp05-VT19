using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem.Play();
        particleSystem.emissionRate = 0f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Offhand"))
        {
            GetComponentInParent<Animator>().SetTrigger("Parried");
        }
        else if (collision.collider.CompareTag("Player"))
        {
            DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.collider.gameObject);
            damageEvent.FireEvent();

            ParticleEvent particle = new ParticleEvent(transform.position, particleSystem);
            particle.FireEvent();
            particleSystem.emissionRate = 1f;
        }
    }
}
//foreach (ContactPoint contact in collision.contacts)
//{
//    HitEvent hitEvent = new HitEvent(contact);
//    hitEvent.FireEvent();
//}

