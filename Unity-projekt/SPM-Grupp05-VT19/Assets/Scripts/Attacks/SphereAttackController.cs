using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAttackController : AttackController
{
    private SphereCollider sphereCollider;

    public override void CheckForCollision()
    {
        sphereCollider = GetComponent<SphereCollider>();

        Collider[] actorsHit = Physics.OverlapSphere(transform.position, sphereCollider.radius, collisionLayerMask);

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
