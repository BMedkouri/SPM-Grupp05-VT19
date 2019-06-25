using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AoeAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (CompareTag("EnemyWeapon"))
        {
            if (collision.collider.CompareTag("Player"))
            {
                DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.collider.gameObject);
                damageEvent.FireEvent();
            }
        }
        else if (CompareTag("PlayerWeapon"))
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                collision.collider.GetComponent<BehaviourTree>().CanDoDarkAttack = false;
                collision.collider.GetComponent<BehaviourTree>().StartResetBool();
                DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.collider.gameObject);
                damageEvent.FireEvent();
            }
        }
    }
}
