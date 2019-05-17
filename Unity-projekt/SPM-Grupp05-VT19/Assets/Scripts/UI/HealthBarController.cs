//Author: Bilal El Medkouri

using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    // Attributes

    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Text healthText;
    [SerializeField] private bool useHealthText;
    [SerializeField] private bool enableHealthBarAfterTakingDamage;
    private float currentHealth, maxHealth;

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
            currentHealth = value;
            UpdateHealthBar();
        }
    }


    // Methods
    private void Awake()
    {
        if (enableHealthBarAfterTakingDamage)
        {
            healthSlider.gameObject.SetActive(false);
        }
    }

    private void UpdateHealthBar()
    {
        if (useHealthText)
        {
            // Text setter
            healthText.text = Mathf.Round(currentHealth) + "/" + maxHealth;
        }

        // Slider setters
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        if (healthSlider.gameObject.activeSelf == false && currentHealth < maxHealth)
        {
            healthSlider.gameObject.SetActive(true);
        }
    }
}
