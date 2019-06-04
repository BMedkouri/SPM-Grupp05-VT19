//Main author: Bilal El Medkouri
//Secondary author: Anders Ragnar

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : StateMachine
{
    #region Variables

    // Player reference/static instance
    public static Player PlayerReference { get; private set; }

    #region UI
    [Header("UI reference")]
    [SerializeField] private GameObject canvas;
    private UIController UIController;
    #endregion UI

    #region Components
    public Animator Animator { get; set; }
    public MovementInput MovementInput { get; set; }
    #endregion Components

    #region Health
    public HealthComponent HealthComponent { get; private set; }
    #endregion Health

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
    public PlayerEquipmentHandler PlayerEquipmentHandler { get; private set; }
    #endregion Equipables

    #region IsHolyNovaUnlocked
    public bool IsHolyNovaUnlocked { get; set; }
    #endregion IsHolyNovaUnlocked 

    #region LevelTwoKey
    public bool HasLevelTwoKey { get; set; }
    #endregion LevelTwoKey

    #endregion Variables

    #region Methods
    protected override void Awake()
    {
        PlayerReference = this;

        // Getters
        Animator = GetComponentInChildren<Animator>();
        UIController = canvas.GetComponent<UIController>();
        PlayerEquipmentHandler = GetComponent<PlayerEquipmentHandler>();
        MovementInput = GetComponent<MovementInput>();

        // Health
        HealthComponent = GetComponent<HealthComponent>();

        // Stamina
        currentStaminaRegeneration = staminaRegeneration;
        staminaRegenerationTimer = staminaRegenerationCooldown;
        MaxStamina = maxStamina;
        UIController.MaxStamina = MaxStamina;

        // Energy
        currentEnergyRegeneration = energyRegeneration;
        energyRegenerationTimer = energyRegenerationCooldown;
        MaxEnergy = maxEnergy;
        UIController.MaxEnergy = MaxEnergy;

        // Load player data
        LoadPlayerData();

        base.Awake();
    }

    private void LoadPlayerData()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        // Players position
        if (currentScene == 1)
        {
            MovePlayerOnLoad(currentScene, 200f, 77.5f, 463f); // Default values
        }
        else if (currentScene == 2)
        {
            // MovePlayerOnLoad(currentScene, 0f, 0f, 0f);
        }

        // Health, stamina, and energy
        HealthComponent.CurrentHealth = PlayerPrefs.GetFloat("currentHealth", 100f);
        CurrentStamina = PlayerPrefs.GetFloat("currentStamina", 80f);
        CurrentEnergy = PlayerPrefs.GetFloat("currentEnergy", 30f);

        // Equipment
        PlayerEquipmentHandler.EquippedWeaponID = PlayerPrefs.GetInt("weaponID", 1);
        PlayerEquipmentHandler.EquippedOffhandID = PlayerPrefs.GetInt("offhandID", 0);

        // Holy nova
        int isHolyNovaUnlocked = PlayerPrefs.GetInt("isHolyNovaUnlocked", 0);
        IsHolyNovaUnlocked = isHolyNovaUnlocked == 1 ? true : false;

        // Level two key
        int hasLevelTwoKey = PlayerPrefs.GetInt("hasLevelTwoKey", 0);
        HasLevelTwoKey = hasLevelTwoKey == 1 ? true : false;
    }

    private void MovePlayerOnLoad(int currentScene, float defaultX, float defaultY, float defaultZ)
    {
        float x, y, z;
        x = PlayerPrefs.GetFloat("playerXLevel" + currentScene, defaultX);
        y = PlayerPrefs.GetFloat("playerYLevel" + currentScene, defaultY);
        z = PlayerPrefs.GetFloat("playerZLevel" + currentScene, defaultZ);
        transform.position = new Vector3(x, y, z);
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

    public void DisableScript()
    {
        enabled = false;
    }
    #endregion Methods
}
