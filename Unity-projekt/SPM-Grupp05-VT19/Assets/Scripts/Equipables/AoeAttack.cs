using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeAttack : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(DestroyObject());
    }
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
        }else if (CompareTag("PlayerWeapon"))
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.collider.gameObject);
                damageEvent.FireEvent();
            }
        }
    }
    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
   
}
