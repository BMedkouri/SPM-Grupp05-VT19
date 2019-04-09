using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text healthText;

    [SerializeField] private Slider healthSlider;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        // Text setters
        healthText.text = player.GetCurrentHealth() + "/" + player.GetMaxHealth();

        // Slider setters
        healthSlider.value = player.GetCurrentHealth();
        healthSlider.maxValue = player.GetMaxHealth();
    }
}
