﻿//Author: Bilal El Medkouri

using UnityEngine;

/// <summary>
/// Subclass that handles Offhand items. Currently only one exists, but I've made this in case we want to implement more.
/// The offhand item is used for parrying, and for healing.
/// </summary>
public class Offhand : EquipableItems
{
    [SerializeField] private GameObject holyNova;
    // TODO: Connect this to the player's heal.
    [SerializeField] private float itemHealAmount;
    [SerializeField] private AudioSource parry;
    public float ItemHealAmount { get => itemHealAmount; }

    protected override void Awake()
    {
        base.Awake();
        OffhandList.Add(this);
        if (particleSystem != null)
        {
            particleSystem.Play();
            particleSystem.emissionRate = 0f;
        }
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemyWeapon"))
        {
            // TODO: Add parry event
            if (parry != null)
            {
                SoundEvent sound = new SoundEvent(transform.position, parry);
                sound.FireEvent();
            }
            if (particleSystem != null)
            {
                ParticleEvent particle = new ParticleEvent(collision.transform.position, particleSystem);
                particle.FireEvent();

                particleSystem.emissionRate = 1f;
            }
            
            Debug.Log("Parry");
        }

        // Check for collision with enemy?
    }

    public void InstantiateHolyNova()
    {
        GameObject hn = Instantiate(holyNova, transform.position, Quaternion.identity);
    }
}
