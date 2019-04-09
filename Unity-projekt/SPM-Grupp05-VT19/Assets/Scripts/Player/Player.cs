using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    //Attributes
    [HideInInspector] public CapsuleCollider capsuleCollider;
    [HideInInspector] public Vector3 point1;
    [HideInInspector] public Vector3 point2;

    [SerializeField] private float maxHealth; // 100f
    [SerializeField] private float healthRegeneration; // 1f
    [SerializeField] private float healthRegenerationCooldown; // 1f
    private float currentHealth, currentHealthRegeneration, healthRegenerationTimer;

    // Methods
    protected override void Awake()
    {
        currentHealth = maxHealth; currentHealthRegeneration = healthRegeneration; healthRegenerationTimer = healthRegenerationCooldown;

        capsuleCollider = GetComponent<CapsuleCollider>();

        point1 = capsuleCollider.center + Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);
        point2 = capsuleCollider.center + Vector3.down * (capsuleCollider.height / 2 - capsuleCollider.radius);

        base.Awake();
    }

    public void HealthRegeneration()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= maxHealth - currentHealthRegeneration)
        {
            if (healthRegenerationTimer <= 0)
            {
                currentHealth += currentHealthRegeneration;
                healthRegenerationTimer = healthRegenerationCooldown;
            }
        }
        healthRegenerationTimer -= Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void RecoverHealth(float health)
    {
        currentHealth += health;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
