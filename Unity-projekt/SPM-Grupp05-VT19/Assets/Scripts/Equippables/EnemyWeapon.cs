using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
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
        Debug.Log("Collision");
        if (collision.collider.CompareTag("Player"))
        {
            DamageEvent damageEvent = new DamageEvent(WeaponDamage, transform.parent.gameObject , collision.collider.gameObject);
            damageEvent.FireEvent();

            foreach (ContactPoint contact in collision.contacts)
            {
                HitEvent hitEvent = new HitEvent(contact);
                hitEvent.FireEvent();
            }
        }
    }
}
