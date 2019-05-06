using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Health
    [SerializeField] private Text healthText;
    [SerializeField] private Slider healthSlider;
    private float currentHealth, maxHealth;

    // Stamina
    [SerializeField] private Text staminaText;
    [SerializeField] private Slider staminaSlider;
    private float currentStamina, maxStamina;

    // Energy
    [SerializeField] private Text energyText;
    [SerializeField] private Slider energySlider;
    private float currentEnergy, maxEnergy;

    private void UpdateHealth()
    {
        // Text setter
        healthText.text = Mathf.Round(currentHealth) + "/" + maxHealth;

        // Slider setters
        healthSlider.value = currentHealth;
        healthSlider.maxValue = maxHealth;
    }

    private void UpdateStamina()
    {
        // Text setter
        staminaText.text = Mathf.Round(currentStamina) + "/" + maxStamina;

        // Slider setters
        staminaSlider.value = currentStamina;
        staminaSlider.maxValue = maxStamina;
    }

    private void UpdateEnergy()
    {
        // Text setter
        energyText.text = Mathf.Round(currentEnergy) + "/" + maxEnergy;

        // Slider setters
        energySlider.value = currentEnergy;
        energySlider.maxValue = maxEnergy;
    }

    public void AddHealth(float health)
    {
        currentHealth += health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealth();
    }

    public void RemoveHealth(float health)
    {
        currentHealth -= health;
        UpdateHealth();
    }

    public void SetHealth(float health)
    {
        currentHealth = health;
        UpdateHealth();
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        SetHealth(maxHealth);
    }

    public void AddStamina(float stamina)
    {
        currentStamina += stamina;

        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }

        UpdateStamina();
    }

    public void RemoveStamina(float stamina)
    {
        currentStamina -= stamina;

        if (currentStamina < 0)
        {
            currentStamina = 0;
        }

        UpdateStamina();
    }

    public void SetStamina(float stamina)
    {
        currentStamina = stamina;
        UpdateStamina();
    }

    public void SetMaxStamina(float maxStamina)
    {
        this.maxStamina = maxStamina;
        SetStamina(maxStamina);
    }

    public void AddEnergy(float energy)
    {
        currentEnergy += energy;

        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        UpdateEnergy();
    }

    public void RemoveEnergy(float energy)
    {
        currentEnergy -= energy;

        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }

        UpdateEnergy();
    }

    public void SetEnergy(float energy)
    {
        currentEnergy = energy;
        UpdateEnergy();
    }

    public void SetMaxEnergy(float maxEnergy)
    {
        this.maxEnergy = maxEnergy;
        SetEnergy(maxEnergy);
    }
}
