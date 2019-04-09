using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    
    [HideInInspector] public MeshRenderer Renderer;
    [HideInInspector] public Player player;
    [HideInInspector] public PhysicsComponent physics;
    public LayerMask visionBlock;

    [SerializeField] private float maxHealth; // 100f
    private float currentHealth;

    protected override void Awake()
    {
    	currentHealth = maxHealth;
        physics = GetComponent<PhysicsComponent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Renderer = GetComponent<MeshRenderer>();
        base.Awake();
        visionBlock = LayerMask.GetMask("Geometry");
    }
   
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
