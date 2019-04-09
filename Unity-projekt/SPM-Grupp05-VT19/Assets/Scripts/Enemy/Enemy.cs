using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : StateMachine
{
    
    [HideInInspector] public MeshRenderer Renderer;
    [HideInInspector] public Player player;
    [HideInInspector] public PhysicsComponent physics;
    [HideInInspector] public LayerMask visionBlock;

    [SerializeField] private float maxHealth; // 100f
    private float currentHealth;

    protected override void Awake()
    {
    	Renderer = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        physics = GetComponent<PhysicsComponent>();
        visionBlock = LayerMask.GetMask("Geometry");

        currentHealth = maxHealth;

        base.Awake();
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

    public bool CanSeePlayer()
    {
        return !Physics.Linecast(transform.position, player.transform.position, visionBlock);
    }

    public float GetDistance()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }
}
