using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private AudioSource hit;

    private void Awake()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
            particleSystem.emissionRate = 0f;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Offhand"))
        {
            Debug.Log("Parried");
            GetComponentInParent<Animator>().SetTrigger("Parried");
            return;
        }
       
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("Attack makes damage");
            DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.gameObject);
            damageEvent.FireEvent();

            if(hit != null)
            {
                SoundEvent sound = new SoundEvent(transform.position, hit);
                sound.FireEvent();
            }
            if (particleSystem != null)
            {
                ParticleEvent particle = new ParticleEvent(transform.position, particleSystem);
                particle.FireEvent();
                particleSystem.emissionRate = 1f;
            }
        }
    }
}

