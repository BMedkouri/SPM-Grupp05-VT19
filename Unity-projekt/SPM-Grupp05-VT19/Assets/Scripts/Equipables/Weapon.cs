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
        if (CompareTag("PlayerWeapon"))
        {
            
            if (collision.collider.CompareTag("Enemy"))
            {
                DamageEvent damageEvent = new DamageEvent(ItemDamage, Player.PlayerReference.gameObject, collision.collider.gameObject);
                damageEvent.FireEvent();

                foreach (ContactPoint contact in collision.contacts)
                {
                    HitEvent hitEvent = new HitEvent(contact);
                    hitEvent.FireEvent();
                }
            }
        }
        else if (CompareTag("EnemyWeapon"))
        {
            if (collision.collider.CompareTag("Player"))
            {
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
}
