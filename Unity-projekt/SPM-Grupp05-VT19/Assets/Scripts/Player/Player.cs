using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    //Attributes
    [HideInInspector] public PhysicsComponent physics;
    [HideInInspector] public CapsuleCollider capsuleCollider;
    [HideInInspector] public RaycastHit hitInfo;
    [HideInInspector] public Vector3 sumOfSnapsPerFrame;
    [HideInInspector] public Vector3 point1;
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

        sumOfSnapsPerFrame = new Vector3();

        capsuleCollider = GetComponent<CapsuleCollider>();
        physics = GetComponent<PhysicsComponent>();

        point1 = capsuleCollider.center + Vector3.up * (capsuleCollider.height / 2 - capsuleCollider.radius);
        point2 = capsuleCollider.center + Vector3.down * (capsuleCollider.height / 2 - capsuleCollider.radius);

        base.Awake();
    }

    public void PlayerInput(float jumpHeight, float acceleration, float turnSpeedModifier)
    {
        //Regeneration
        HealthRegeneration();

        //Takes input from player
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //Multiplies input with camera rotation (so that we move in accordance with the camera, and not the world coordinates)
        if (Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out hitInfo, skinWidth + groundCheckDistance, geometryLayer))
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, hitInfo.normal).normalized;
        }
        else
        {
            direction = Vector3.ProjectOnPlane(Camera.main.transform.rotation * direction, Vector3.up).normalized;
        }

        //Movement
        if (direction != Vector3.zero)
        {
            physics.Accelerate(direction, acceleration, turnSpeedModifier);
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.SphereCast(transform.position + point2, capsuleCollider.radius, Vector3.down, out hitInfo, skinWidth + groundCheckDistance, geometryLayer))
            {
                physics.Jump(jumpHeight);
            }
        }

        //Take damage - For testing purposes
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10f);
        }

        //Checks for collisions
        CollisionCheck();

        //Moves player and resets snaps per frame
        transform.position += physics.GetVelocity() * Time.deltaTime - sumOfSnapsPerFrame;
        sumOfSnapsPerFrame = Vector3.zero;
    }

    private void CollisionCheck()
    {
        int escape = 100;
        do
        {
            if (Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, physics.GetVelocity().normalized, out hitInfo, physics.GetVelocity().magnitude * Time.deltaTime + skinWidth, geometryLayer))
            {
                if (Physics.CapsuleCast(transform.position + point1, transform.position + point2, capsuleCollider.radius, -hitInfo.normal, out hitInfo, physics.GetVelocity().magnitude * Time.deltaTime + skinWidth, geometryLayer))
                {
                    if (hitInfo.distance - skinWidth > skinWidth)
                    {
                        sumOfSnapsPerFrame += -hitInfo.normal * (hitInfo.distance - skinWidth);
                        transform.position += -hitInfo.normal * (hitInfo.distance - skinWidth);
                    }
                    else
                    {
                        sumOfSnapsPerFrame += -hitInfo.normal * (-skinWidth);
                        transform.position += -hitInfo.normal * (-skinWidth);
                    }
                    //Calculate and apply forces
                    physics.CalculateAndApplyForces(hitInfo.normal);
                }
            }
            escape--;
        } while (hitInfo.collider != null && escape > 0);
    }

    private void HealthRegeneration()
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

    private void TakeDamage(float damage)
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
}
