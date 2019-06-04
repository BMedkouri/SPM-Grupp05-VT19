//Author: Bilal El Medkouri

using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    #region Variables

    [Header("UI reference")]
    [SerializeField] private GameObject canvas;
    private HealthBarController healthBarController;

    [Header("Health attributes")]
    [SerializeField] private float maxHealth;
    public float MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = value;
            CurrentHealth = maxHealth;
        }
    }

    #region CurrentHealth
    private float currentHealth;
    public float CurrentHealth
    {
        get => currentHealth;
        set
        {
            // In heal cases
            // Might be obsolete
            if (value > MaxHealth)
            {
                currentHealth = MaxHealth;
            }
            else if (value > currentHealth)
            {
                currentHealth = value;
            }

            // In damage cases
            else if (value < currentHealth)
            {
                if (IsInvulnerable == true) { }

                else if (value <= 0)
                {
                    currentHealth = value;
                    if (gameObject.CompareTag("Player"))
                    {
                        Player.Instance.Transition<PlayerDeathState>();
                    }
                    else
                    {
                        GetComponent<Animator>().SetTrigger("Death");
                    }
                }
                else
                {
                    currentHealth = value;
                }
            }

            healthBarController.CurrentHealth = currentHealth;
        }
    }
    #endregion CurrentHealth

    public bool IsInvulnerable { get; set; }

    #endregion Variables

    #region Methods
    private void Awake()
    {
        healthBarController = canvas.GetComponent<HealthBarController>();
        healthBarController.MaxHealth = maxHealth;
        MaxHealth = maxHealth;
        IsInvulnerable = false;
    }

    private void HealPlayer()
    {
        if (gameObject.CompareTag("Player"))
        {
            float healAmount = GetComponent<Player>().PlayerEquipmentHandler.Offhand.ItemHealAmount;
            CurrentHealth += healAmount;
        }
    }
    #endregion Methods
}
