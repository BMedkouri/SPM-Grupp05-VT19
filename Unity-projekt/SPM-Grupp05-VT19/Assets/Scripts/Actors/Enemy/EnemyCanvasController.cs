//Author: Bilal El Medkouri

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates instances of canvases located in world space, that shows hp bars for enemies, after they've taken damage.
/// </summary>
public class EnemyCanvasController : MonoBehaviour
{
    private float currentHealth, maxHealth;
    [SerializeField] private Slider healthSlider;

    private Vector3 targetPosition;
    
    /// <summary>
    /// Makes sure that the health slider is disabled from the start.
    /// </summary>
    private void Awake()
    {
        healthSlider.gameObject.SetActive(false);
    }

    /// <summary>
    /// This checks to see if the enemy has taken damage, and then activates the health slider the first time it does (take damage).
    /// I'm thinking of changing this so that it doesn't run this check in update, but does it somewhere else instead.
    /// 
    /// If the health slider is active, rotate the canvas towards the player.
    /// </summary>
    private void Update()
    {
        if (!healthSlider.IsActive() && currentHealth < maxHealth)
            healthSlider.gameObject.SetActive(true);

        if(healthSlider.IsActive())
        {
            targetPosition = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
            transform.LookAt(targetPosition);
        }
    }

    private void UpdateHealth()
    {
        healthSlider.value = currentHealth;
        healthSlider.maxValue = maxHealth;
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

    public void SetMaxHealth(float maxHealth)
    {
        currentHealth = maxHealth;
        this.maxHealth = maxHealth;
        UpdateHealth();
    }
}
