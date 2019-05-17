//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;

public class Player : StateMachine
{
    #region Variables

    // Player reference/static instance
    public static Player PlayerReference { get; private set; }


    [Header("UI reference")]
    [SerializeField] private GameObject canvas;
    private UIController UIController;


    [Header("Movement speed")]
    [SerializeField] private float acceleration;
    public float Acceleration { get => acceleration; set => acceleration = value; }


    #region Stamina
    [Header("Stamina")]
    [SerializeField] private float maxStamina; // 100f
    [SerializeField] private float staminaRegeneration; // 5f
    [SerializeField] private float staminaRegenerationCooldown; // 1f
    private float currentStamina, currentStaminaRegeneration, staminaRegenerationTimer;

    public float MaxStamina
    {
        get => maxStamina;
        set
        {
            maxStamina = value;
            CurrentStamina = maxStamina;
        }
    }

    public float CurrentStamina
    {
        get => currentStamina;
        set
        {
            if (value > MaxStamina)
            {
                currentStamina = MaxStamina;
            }
            else if (value < 0)
            {
                currentStamina = 0;
            }
            else
            {
                currentStamina = value;
            }

            UIController.CurrentStamina = currentStamina;
        }
    }
    #endregion Stamina

    #region Energy
    [Header("Energy")]
    [SerializeField] private float maxEnergy; // 30f (?)
    [SerializeField] private float energyRegeneration; // 1f
    [SerializeField] private float energyRegenerationCooldown; // 5f
    private float currentEnergy, currentEnergyRegeneration, energyRegenerationTimer;

    public float MaxEnergy
    {
        get => maxEnergy;
        set
        {
            maxEnergy = value;
            CurrentEnergy = maxEnergy;
        }
    }

    public float CurrentEnergy
    {
        get => currentEnergy;
        set
        {
            if (value > MaxEnergy)
            {
                currentEnergy = MaxEnergy;
            }
            else if (value < 0)
            {
                currentEnergy = 0;
            }
            else
            {
                currentEnergy = value;
            }

            UIController.CurrentEnergy = currentEnergy;
        }
    }
    #endregion Energy

    #region Equipables

    [Header("Weapon")]
    [SerializeField] private GameObject activeWeaponGameObject;
    public GameObject ActiveWeaponGameObject
    {
        get => activeWeaponGameObject;
        set
        {
            activeWeaponGameObject = value;
            ActiveWeaponWeapon = activeWeaponGameObject.GetComponent<Weapon>();
        }
    }

    public Weapon ActiveWeaponWeapon { get; private set; }


    [Header("Offhand")]
    [SerializeField] private GameObject activeOffhandGameObject;
    public GameObject ActiveOffhandGameObject
    {
        get => activeOffhandGameObject;
        set
        {
            activeOffhandGameObject = value;
            ActiveOffhandOffhand = activeOffhandGameObject.GetComponent<Offhand>();
        }
    }

    public Offhand ActiveOffhandOffhand { get; private set; }

    #endregion Equipables

    // Components
    public PhysicsComponent Physics { get; set; }
    public CollisionDetection Collision { get; set; }
    public Animator Animator { get; set; }
    public RotatePlayer RotatePlayer { get; set; }

    #endregion Variables


    #region Methods
    protected override void Awake()
    {
        PlayerReference = this;

        // Weapon
        ActiveWeaponWeapon = ActiveWeaponGameObject.GetComponent<Weapon>();

        // Offhand
        ActiveOffhandOffhand = ActiveOffhandGameObject.GetComponent<Offhand>();

        // Stamina
        currentStaminaRegeneration = staminaRegeneration;
        staminaRegenerationTimer = staminaRegenerationCooldown;

        // Energy
        currentEnergyRegeneration = energyRegeneration;
        energyRegenerationTimer = energyRegenerationCooldown;

        // Getters
        Physics = GetComponent<PhysicsComponent>();
        Collision = GetComponent<CollisionDetection>();
        Animator = GetComponentInChildren<Animator>();
        RotatePlayer = GetComponentInChildren<RotatePlayer>();
        UIController = canvas.GetComponent<UIController>();


        base.Awake();
    }

    private void Start()
    {
        // Stamina
        MaxStamina = maxStamina;
        UIController.MaxStamina = MaxStamina;

        // Energy
        MaxEnergy = maxEnergy;
        UIController.MaxEnergy = MaxEnergy;
    }

    public void Regeneration()
    {
        StaminaRegeneration();
        EnergyRegeneration();
    }


    private void StaminaRegeneration()
    {
        if (staminaRegenerationTimer <= 0 && CurrentStamina < MaxStamina)
        {
            CurrentStamina += currentStaminaRegeneration;
            staminaRegenerationTimer = staminaRegenerationCooldown;
        }

        staminaRegenerationTimer -= Time.deltaTime;
    }

    private void EnergyRegeneration()
    {
        if (energyRegenerationTimer <= 0 && CurrentEnergy < MaxEnergy)
        {
            CurrentEnergy += currentEnergyRegeneration;
            energyRegenerationTimer = energyRegenerationCooldown;
        }

        energyRegenerationTimer -= Time.deltaTime;
    }
    #endregion Methods
}
