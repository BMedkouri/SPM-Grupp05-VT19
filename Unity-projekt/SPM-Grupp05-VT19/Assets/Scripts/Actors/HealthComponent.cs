//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    // Health attributes
    [SerializeField] private float maxHealth; // 100f
    [SerializeField] private float healthRegeneration; // 1f
    [SerializeField] private float healthRegenerationCooldown; // 1f
    [SerializeField] private float invulnerabilityPeriod;
    private float currentHealth, currentHealthRegeneration, healthRegenerationTimer, invulnerabilityTimer;
    private bool isDead;

    // Audio and particle effect prefabs
    [SerializeField] private AudioSource onHitSoundEffect;
    [SerializeField] private ParticleSystem onHitParticleEffect;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private ParticleSystem deathParticleEffect;

    private void Awake()
    {
        if(gameObject.layer == 9)
        {
            GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().SetMaxHealth(maxHealth);
        }
        else if(gameObject.layer == 11)
        {
            gameObject.GetComponentInChildren<EnemyCanvasController>().SetMaxHealth(maxHealth);
        }

        // Health
        currentHealth = maxHealth; currentHealthRegeneration = healthRegeneration; healthRegenerationTimer = healthRegenerationCooldown; invulnerabilityTimer = invulnerabilityPeriod;
        isDead = false;
    }

    private void Update()
    {
        HealthRegeneration();
        InvulnerabilityCountdown();
    }

    private void HealthRegeneration()
    {
        if (healthRegenerationTimer <= 0 && currentHealth < maxHealth)
        {
            RecoverHealth(currentHealthRegeneration);
            healthRegenerationTimer = healthRegenerationCooldown;
        }

        healthRegenerationTimer -= Time.deltaTime;
    }

    public void RecoverHealth(float health)
    {
        currentHealth += health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void InvulnerabilityCountdown()
    {
        invulnerabilityTimer -= Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        if (!isDead && invulnerabilityTimer <= 0)
        {
            currentHealth -= damage;
            invulnerabilityTimer = invulnerabilityPeriod;

            DamageEvent damageEvent = new DamageEvent
            {
                Damage = damage,
                DamagedGameObject = gameObject,
                DamagedSoundEffect = onHitSoundEffect,
                DamagedParticleSystem = onHitParticleEffect
            };
            damageEvent.FireEvent();
        }

        if (!isDead && currentHealth <= 0)
        {
            isDead = true;

            // Create a transition for player and enemies into their respective DeathStates

            DeathEvent deathEvent = new DeathEvent
            {
                DyingGameObject = gameObject,
                DeathSound = deathSoundEffect,
                DeathParticle = deathParticleEffect
            };
            deathEvent.FireEvent();
        }
    }
}
