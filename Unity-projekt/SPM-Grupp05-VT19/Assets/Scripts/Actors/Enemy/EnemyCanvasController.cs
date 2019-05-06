using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanvasController : MonoBehaviour
{
    private float currentHealth, maxHealth;
    [SerializeField] private Slider healthSlider;

    private Vector3 targetPosition;
    
    private void Start()
    {
        healthSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (currentHealth < maxHealth && !healthSlider.IsActive())
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
