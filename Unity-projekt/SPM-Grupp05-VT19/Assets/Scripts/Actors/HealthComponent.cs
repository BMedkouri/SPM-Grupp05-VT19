//Author: Bilal El Medkouri

using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    //Attributes

    [Header("UI reference:")]
    [SerializeField] private GameObject canvas;
    private HealthBarController healthBarController;

    [Header("Health attributes:")]
    [SerializeField] private float maxHealth;
    private float currentHealth;


    // Properties
    public float MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = value;
            CurrentHealth = maxHealth;
        }
    }

    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (value > MaxHealth)
            {
                currentHealth = MaxHealth;
            }
            else if (value <= 0)
            {
                currentHealth = value;
                DeathEvent deathEvent = new DeathEvent(gameObject);
                deathEvent.FireEvent();
            }
            else
            {
                currentHealth = value;
            }

            healthBarController.CurrentHealth = currentHealth;
        }
    }

    public bool IsDead { get; private set; }

    // Methods
    private void Awake()
    {
        IsDead = false;
    }

    private void Start()
    {
        healthBarController = canvas.GetComponent<HealthBarController>();
        MaxHealth = maxHealth;
        healthBarController.MaxHealth = MaxHealth;
    }
}
