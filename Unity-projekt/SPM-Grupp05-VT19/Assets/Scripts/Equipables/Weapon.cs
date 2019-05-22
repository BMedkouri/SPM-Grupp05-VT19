//Author: Bilal El Medkouri

using UnityEngine;

public class Weapon : EquipableItems
{
    protected override void Awake()
    {
        base.Awake();
        WeaponList.Add(this);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");

        if (collision.collider.CompareTag("Offhand"))
        {
            // TODO: Add parry event
            Debug.Log("Parry");
        }

        else if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Collision with enemy");

            DamageEvent damageEvent = new DamageEvent(ItemDamage, Player.PlayerReference.gameObject, collision.collider.gameObject);
            damageEvent.FireEvent();

            foreach (ContactPoint contact in collision.contacts)
            {
                HitEvent hitEvent = new HitEvent(contact);
                hitEvent.FireEvent();
            }
        }
    }
}
