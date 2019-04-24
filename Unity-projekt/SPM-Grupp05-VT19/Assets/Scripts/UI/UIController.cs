using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Health
    [SerializeField] private Text healthText;
    [SerializeField] private Slider healthSlider;

    // Stamina
    [SerializeField] private Text staminaText;
    [SerializeField] private Slider staminaSlider;

    // Energy
    [SerializeField] private Text energyText;
    [SerializeField] private Slider energySlider;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        // Text setters
        healthText.text = Mathf.Round(player.GetCurrentHealth()) + "/" + player.GetMaxHealth();
        staminaText.text = Mathf.Round(player.GetCurrentStamina()) + "/" + player.GetMaxStamina();
        energyText.text = Mathf.Round(player.GetCurrentEnergy()) + "/" + player.GetMaxEnergy();

        // Slider setters
        healthSlider.value = player.GetCurrentHealth();
        healthSlider.maxValue = player.GetMaxHealth();

        staminaSlider.value = player.GetCurrentStamina();
        staminaSlider.maxValue = player.GetMaxStamina();

        energySlider.value = player.GetCurrentEnergy();
        energySlider.maxValue = player.GetMaxEnergy();
    }
}
