//Author: Bilal El Medkouri

using UnityEngine;

/// <summary>
/// Subclass that handles weapons.
/// 
/// Deals damage on collision, if Rigidbody.isKinematic == false.
/// RigidB
/// </summary>
public class Weapon : EquipableItems
{
    protected override void Awake()
    {
        base.Awake();
        WeaponList.Add(this);
        if (particleSystem != null)
        {
            particleSystem.Play();
            particleSystem.emissionRate = 0f;
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Offhand"))
        {
            // TODO: Add parry event
            Debug.Log("Parry");
        }

        else if (collision.collider.CompareTag("Enemy"))
        {
            DamageEvent damageEvent = new DamageEvent(ItemDamage, Player.PlayerReference.gameObject, collision.collider.gameObject);
            damageEvent.FireEvent();

            if (particleSystem != null)
            {
                ParticleEvent particle = new ParticleEvent(transform.position, particleSystem);
                particle.FireEvent();
                particleSystem.emissionRate = 1f;
            }

            if (collision.collider.GetComponent<BehaviourTree>() is WolfBehaviourTree)
            {
                collision.collider.GetComponent<Animator>().SetTrigger("TakeHit");
            }
            foreach (ContactPoint contact in collision.contacts)
            {
                HitEvent hitEvent = new HitEvent(contact);
                hitEvent.FireEvent();
            }
        }
    }
}
