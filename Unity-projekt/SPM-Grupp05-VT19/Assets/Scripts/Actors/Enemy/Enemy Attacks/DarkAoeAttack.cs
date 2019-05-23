using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkAoeAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.collider.gameObject);
            damageEvent.FireEvent();
        }
    }
}
