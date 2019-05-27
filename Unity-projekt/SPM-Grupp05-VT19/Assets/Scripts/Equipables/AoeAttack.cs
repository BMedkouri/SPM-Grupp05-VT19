using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
                Debug.Log("Dark Attack Collision");
                DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.collider.gameObject);
                damageEvent.FireEvent();
            }
        }else if (CompareTag("PlayerWeapon"))
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                Debug.Log("AOE interupt");
                collision.collider.GetComponent<BehaviourTree>().CanDoDarkAttack = false;
                Debug.Log(collision.collider.GetComponent<BehaviourTree>().CanDoDarkAttack);
                DamageEvent damageEvent = new DamageEvent(damage, gameObject, collision.collider.gameObject);
                damageEvent.FireEvent();
            }
        }
    }
    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

}
