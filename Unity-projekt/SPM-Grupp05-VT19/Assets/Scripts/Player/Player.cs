using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    //Attributes
    [HideInInspector] public PhysicsComponent physics;
    [HideInInspector] public CapsuleCollider capsuleCollider;
    [HideInInspector] public Vector3 point2;

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

        physics = GetComponent<PhysicsComponent>();
        capsuleCollider = GetComponent<CapsuleCollider>();

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
                RecoverHealth(currentHealthRegeneration);
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

    public float GetSkinWidth()
    {
        return skinWidth;
    }

    public float GetGroundCheckDistance()
    {
        return groundCheckDistance;
    }

    //Ta eventuellt bort denna och ersätt till en annan pekare, om allt ändå bara pekar åt ett lager
    public LayerMask GetGeometryLayer()
    {
        return geometryLayer;
    }

    public bool IsGrounded()
    {
        return Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out RaycastHit hitInfo, skinWidth + groundCheckDistance, geometryLayer);
    }

}
