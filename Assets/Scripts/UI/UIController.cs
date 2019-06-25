//Author: Bilal El Medkouri

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script in charge of changing the UI elements.
/// It used to update all values using an Update(), but now it only updates an element once it is changed.
/// </summary>
public class UIController : MonoBehaviour
{
    [Header("Stamina")]
    [SerializeField] private Text staminaText;
    [SerializeField] private Slider staminaSlider;
    private float currentStamina, maxStamina;

    [Header("Energy")]
    [SerializeField] private Text energyText;
    [SerializeField] private Slider energySlider;
    private float currentEnergy, maxEnergy;



    // Properties

    // Stamina
    public float MaxStamina
    {
        get => maxStamina;
        set
        {
            maxStamina = value;
            staminaSlider.maxValue = maxStamina;
            CurrentStamina = maxStamina;
        }
    }

    public float CurrentStamina
    {
        get => currentStamina;
        set
        {
            currentStamina = value;
            UpdateStaminaBar();
        }
    }

    // Energy
    public float MaxEnergy
    {
        get => maxEnergy;
        set
        {
            maxEnergy = value;
            energySlider.maxValue = maxEnergy;
            CurrentEnergy = maxEnergy;
        }
    }

    public float CurrentEnergy
    {
        get => currentEnergy;
        set
        {
            currentEnergy = value;
            UpdateEnergyBar();
        }
    }

    //Methods
    private void UpdateStaminaBar()
    {
        // Text setter
        staminaText.text = Mathf.Round(currentStamina) + "/" + maxStamina;

        // Slider setter
        staminaSlider.value = CurrentStamina;
    }

    private void UpdateEnergyBar()
    {
        // Text setter
        energyText.text = Mathf.Round(currentEnergy) + "/" + maxEnergy;

        // Slider setter
        energySlider.value = currentEnergy;
    }
}
