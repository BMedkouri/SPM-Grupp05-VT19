//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles all BoxAttacks, and is attached to a BoxAttack-prefab.
/// </summary>
public class BoxAttackController : AttackController
{
    private BoxCollider boxCollider;
    
    /// <summary>
    /// CheckForCollision creates an array of colliders, and then fills it with anything that is inside of our boxCollider if it matches the layers selected from collisionLayerMask.
    /// 
    /// If no actors are hit - actors specifically, because we don't want actors hitting geometry or other objects - a DebugEvent is fired, letting us know that our aim is off.
    /// If we do hit any actors, we'll first check for a parry, if we don't hit a parry we'll proceed to damage the actor, if we do, we're immobilized for a short duration.
    /// </summary>
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
                Debug.Log(ac.tag);
                if (ac.CompareTag("Parry"))
                {
                    
                    Debug.Log("Parry");
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
