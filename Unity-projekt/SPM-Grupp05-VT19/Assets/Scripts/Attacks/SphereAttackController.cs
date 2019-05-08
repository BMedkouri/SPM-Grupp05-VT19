//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This attack handles all sphere attacks, and is attached to a SphereAttack-prefab.
/// </summary>
public class SphereAttackController : AttackController
{
    private SphereCollider sphereCollider;

    /// <summary>
    /// CheckForCollision creates an array of colliders, and then fills it with anything that is inside of our sphereCollider if it matches the layers selected from collisionLayerMask.
    /// 
    /// If no actors are hit - actors specifically, because we don't want actors hitting geometry or other objects - a DebugEvent is fired, letting us know that our aim is off.
    /// If we do hit any actors, we'll proceed to deal damage to them.
    /// We don't check for any parries here, since sphere attacks will only be magic attacks, and we don't want our magic attacks to be parryable.
    /// </summary>
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
