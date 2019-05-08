using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAttackController : AttackController
{
    private BoxCollider boxCollider;
    
    public override void CheckForCollision()
    {
        boxCollider = GetComponent<BoxCollider>();

        Collider[] actorsHit = Physics.OverlapBox(transform.position + boxCollider.center, boxCollider.size / 2, Quaternion.identity, collisionLayerMask);

        if (actorsHit.Length == 0)
        {
            DebugEvent debugEvent = new DebugEvent
            {
                DebugMessage = attackName + " hits nothing."
            };
            debugEvent.FireEvent();
        }

        else
        {
            DebugEvent debugEvent = new DebugEvent
            {
                DebugMessage = attackName + " hits " + actorsHit.Length + " actors for " + attackDamage + " damage."
            };
            debugEvent.FireEvent();

            foreach (Collider ac in actorsHit)
            {
                if (ac.CompareTag("Parry"))
                {
                    if(gameObject.transform.parent.tag == "EnemyAttacks") {

                        GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().Transition<EnemyImmobilisedState>();
                    }
                    else if(gameObject.transform.parent.tag == "PlayerAttacks")
                    {
                        //gameObject.GetComponentInParent<Player>().Transition<PlayerImmobilisedState??>();
                    }
                }
                else
                {
                    if (gameObject.transform.parent.tag == "EnemyAttacks")
                    {
                        ac.GetComponent<HealthComponent>().TakeDamage(attackDamage);
                    }
                    else if (gameObject.transform.parent.tag == "PlayerAttacks")
                    {
                        ac.GetComponent<HealthComponent>().TakeDamage(attackDamage + GameObject.FindGameObjectWithTag("Player").GetComponent<ActiveWeapon>().GetActiveWeaponDamage());
                    }
                    //GetComponent<ActiveWeapon>().GetActiveWeaponDamage()
                }
            }
        }
    }
}
