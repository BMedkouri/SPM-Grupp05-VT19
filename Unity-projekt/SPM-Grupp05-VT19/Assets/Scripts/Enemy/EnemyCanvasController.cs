using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanvasController : MonoBehaviour
{
    private Enemy enemy;
    private float enemyCurrentHealth, enemyMaxHealth;
    [SerializeField] private Slider enemyHealthSlider;

    private Vector3 targetPosition;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void Start()
    {
        enemyCurrentHealth = enemy.GetCurrentHealth();
        enemyMaxHealth = enemy.GetMaxHealth();

        enemyHealthSlider.value = enemyCurrentHealth;
        enemyHealthSlider.maxValue = enemyMaxHealth;

        enemyHealthSlider.gameObject.SetActive(false);
    }

    private void Update()
    {
        targetPosition = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.LookAt(targetPosition);

        enemyCurrentHealth = enemy.GetCurrentHealth();
        enemyHealthSlider.value = enemyCurrentHealth;

        if (enemyCurrentHealth < enemyMaxHealth && !enemyHealthSlider.IsActive())
            enemyHealthSlider.gameObject.SetActive(true);
    }
}
