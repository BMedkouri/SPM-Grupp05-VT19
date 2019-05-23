using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.collider.gameObject);
            damageEvent.FireEvent();

            foreach (ContactPoint contact in collision.contacts)
            {
                HitEvent hitEvent = new HitEvent(contact);
                hitEvent.FireEvent();
            }
        }
    }

}

