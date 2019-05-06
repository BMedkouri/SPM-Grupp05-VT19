using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    // Attributes

    // Physics
    [SerializeField] private float acceleration;            // 14f
    [SerializeField] private float turnSpeedModifier;       // 5f

    // Components
    [HideInInspector] public MeshRenderer renderer;
    [HideInInspector] public PhysicsComponent physics;
    [HideInInspector] public CollisionDetection collision;
    [HideInInspector] public Animator animator;
    
    // Stamina attributes
    [SerializeField] private float maxStamina; // 100f
    [SerializeField] private float staminaRegeneration; // 5f
    [SerializeField] private float staminaRegenerationCooldown; // 1f
    private float currentStamina, currentStaminaRegeneration, staminaRegenerationTimer;

    // Energy attributes
    [SerializeField] private float maxEnergy; // 30f (?)
    [SerializeField] private float energyRegeneration; // 1f
    [SerializeField] private float energyRegenerationCooldown; // 5f
    private float currentEnergy, currentEnergyRegeneration, energyRegenerationTimer;
    
    [HideInInspector] public RotatePlayer rotate;
    
    public float Acceleration { get => acceleration; set => acceleration = value; }
    public float TurnSpeedModifier { get => turnSpeedModifier; set => turnSpeedModifier = value; }

    // Methods
    protected override void Awake()
    {
    

        rotate = GetComponentInChildren<RotatePlayer>();
        
        // Stamina
        currentStamina = maxStamina; currentStaminaRegeneration = staminaRegeneration; staminaRegenerationTimer = staminaRegenerationCooldown;

        // Energy
        currentEnergy = maxEnergy; currentEnergyRegeneration = energyRegeneration; energyRegenerationTimer = energyRegenerationCooldown;

        // GetComponent<T>
        renderer = transform.Find("MeshRenderer").GetComponent<MeshRenderer>();
        physics = GetComponent<PhysicsComponent>();
        collision = GetComponent<CollisionDetection>();
        animator = GetComponent<Animator>();        

        base.Awake();
    }

    public void Regeneration()
    {
        StaminaRegeneration();
        EnergyRegeneration();
    }
    
    // Stamina methods *************************************************************************************
    public void StaminaRegeneration()
    {
        if (staminaRegenerationTimer <= 0 && currentStamina < maxStamina)
        {
            RecoverStamina(currentStaminaRegeneration);
            staminaRegenerationTimer = staminaRegenerationCooldown;
        }
        
        staminaRegenerationTimer -= Time.deltaTime;
    }

    public void RecoverStamina(float stamina)
    {
        currentStamina += stamina;

        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }

    public void LoseStamina(float staminaExpenditure)
    {
        currentStamina -= staminaExpenditure;

        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }
    // End of stamina methods ******************************************************************************

    // Energy methods **************************************************************************************
    public void EnergyRegeneration()
    {
        if (energyRegenerationTimer <= 0 && currentEnergy < maxEnergy)
        {
            RecoverEnergy(currentEnergyRegeneration);
            energyRegenerationTimer = energyRegenerationCooldown;
        }

        energyRegenerationTimer -= Time.deltaTime;
    }

    public void RecoverEnergy(float energy)
    {
        currentEnergy += energy;

        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }

    public void LoseEnergy(float energyExpenditure)
    {
        currentEnergy -= energyExpenditure;

        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }
    }
    // End of energy methods *******************************************************************************

    // Getters
    public float GetCurrentStamina()
    {
        return currentStamina;
    }

    public float GetMaxStamina()
    {
        return maxStamina;
    }

    public float GetCurrentEnergy()
    {
        return currentEnergy;
    }

    public float GetMaxEnergy()
    {
        return maxEnergy;
    }
}
