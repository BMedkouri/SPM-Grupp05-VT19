using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : StateMachine
{
    
    [HideInInspector] public MeshRenderer renderer;
    [HideInInspector] public Player player;
    [HideInInspector] public PhysicsComponent physics;
    [HideInInspector] public LayerMask visionBlock;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animator;
    
    [SerializeField] private GameObject[] patrolLocations;
    [SerializeField] private float maxHealth; // 100f
    [SerializeField] private float invulnerabilityPeriod;
    private float currentHealth, invulnerabilityTimer;
    private bool isDead;

    // Audio and particle effect prefabs
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private ParticleSystem deathParticleEffect;

    protected override void Awake()
    {
    	renderer = GetComponent<MeshRenderer>();
	    agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        physics = GetComponent<PhysicsComponent>();
        visionBlock = LayerMask.GetMask("Geometry");
        animator = GetComponent<Animator>();
        
        currentHealth = maxHealth; invulnerabilityTimer = 0;
        isDead = false;

        base.Awake();
    }

    public void InvulnerabilityCountdown()
    {
        invulnerabilityTimer -= Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        if (!isDead && invulnerabilityTimer <= 0)
        {
            currentHealth -= damage;
            invulnerabilityTimer = invulnerabilityPeriod;
        }

        if (!isDead && currentHealth <= 0)
        {
            isDead = true;
            Transition<EnemyDeathState>();
        }
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
    public Vector3[] GetMovePoints()
    {
        Vector3[] movePoints = new Vector3[patrolLocations.Length];
        for(int i = 0; i < patrolLocations.Length; i++)
        {
            Debug.Log("MovePoints");
            movePoints[i] = patrolLocations[i].transform.position;
        }
        return movePoints;
    }

    public AudioSource GetDeathSound()
    {
        return deathSound;
    }

    public ParticleSystem GetDeathParticle()
    {
        return deathParticleEffect;
    }
}
