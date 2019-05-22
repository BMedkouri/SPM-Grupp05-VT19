//Author: Bilal El Medkouri

using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Attributes
    [Header("Weapon properties")]
    [SerializeField] private string weaponName;
    [SerializeField] private float weaponDamage;
    public string WeaponName { get => weaponName; }
    public float WeaponDamage { get => weaponDamage; }


    public Rigidbody Rigidbody { get; private set; }


    // TODO: Add possible trail and particle effects

    // Methods
    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (CompareTag("PlayerWeapon"))
        {
            if (collision.collider.CompareTag("Offhand"))
            {
                // TODO: Add parry event
                Debug.Log("Parry");
            }

            else if (collision.collider.CompareTag("Enemy"))
            {
                DamageEvent damageEvent = new DamageEvent(WeaponDamage, Player.PlayerReference.gameObject, collision.collider.gameObject);
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
                DamageEvent damageEvent = new DamageEvent(WeaponDamage, transform.parent.gameObject, collision.collider.gameObject);
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
