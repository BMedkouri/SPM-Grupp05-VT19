using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    //Attributes
    [HideInInspector] public CapsuleCollider capsuleCollider;
    [HideInInspector] public RaycastHit hitInfo;
    [HideInInspector] public Vector3 sumOfSnapsPerFrame;
    [HideInInspector] private Vector3 point1;
    [HideInInspector] private Vector3 point2;

    [SerializeField] private float skinWidth;               // 0.063f
    [SerializeField] private float groundCheckDistance;     // 0.063f
    [SerializeField] private LayerMask geometryLayer;

    [SerializeField] private float maxHealth; // 100f
    [SerializeField] private float healthRegeneration; // 1f
    [SerializeField] private float healthRegenerationCooldown; // 1f
    private float currentHealth, currentHealthRegeneration, healthRegenerationTimer;

    // Methods
    protected override void Awake()
    {
        currentHealth = maxHealth; currentHealthRegeneration = healthRegeneration; healthRegenerationTimer = healthRegenerationCooldown;

        sumOfSnapsPerFrame = new Vector3();

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

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
    public bool IsGrounded()
    {
        return Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out hitInfo, skinWidth + groundCheckDistance, geometryLayer);
    }
}
