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
                ac.GetComponent<HealthComponent>().TakeDamage(attackDamage);
            }
        }
    }
}
