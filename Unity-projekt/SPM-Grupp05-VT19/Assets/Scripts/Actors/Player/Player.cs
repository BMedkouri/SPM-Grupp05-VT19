//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StateMachine
{
    // Attributes

    // Physics
    [SerializeField] private float acceleration;            // 14f

    // Components
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

    // Methods
    protected override void Awake()
    {
        // Stamina
        currentStamina = maxStamina; currentStaminaRegeneration = staminaRegeneration; staminaRegenerationTimer = staminaRegenerationCooldown;

        // Energy
        currentEnergy = maxEnergy; currentEnergyRegeneration = energyRegeneration; energyRegenerationTimer = energyRegenerationCooldown;

        // UI
        GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().SetMaxStamina(maxStamina);
        GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().SetMaxEnergy(maxEnergy);

        // GetComponent<T>
        physics = GetComponent<PhysicsComponent>();
        collision = GetComponent<CollisionDetection>();
        animator = GameObject.FindGameObjectWithTag("Animation").GetComponent<Animator>();
        rotate = GetComponentInChildren<RotatePlayer>();

        base.Awake();
    }

    public void Regeneration()
    {
        StaminaRegeneration();
        EnergyRegeneration();
    }
    
    // Stamina methods *************************************************************************************
    private void StaminaRegeneration()
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

        UpdateStaminaUI();
    }

    public void LoseStamina(float staminaExpenditure)
    {
        currentStamina -= staminaExpenditure;

        if (currentStamina < 0)
        {
            currentStamina = 0;
        }

        UpdateStaminaUI();
    }

    private void UpdateStaminaUI()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().SetStamina(currentStamina);
    }
    // End of stamina methods ******************************************************************************

    // Energy methods **************************************************************************************
    private void EnergyRegeneration()
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

        UpdateEnergyUI();
    }

    public void LoseEnergy(float energyExpenditure)
    {
        currentEnergy -= energyExpenditure;

        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }

        UpdateEnergyUI();
    }

    private void UpdateEnergyUI()
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<UIController>().SetEnergy(currentEnergy);
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
