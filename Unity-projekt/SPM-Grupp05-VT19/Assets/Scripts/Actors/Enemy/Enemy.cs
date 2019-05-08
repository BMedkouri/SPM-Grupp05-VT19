using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * @author Bilal El Medkouri
 * @author Anders Ragnar
 */
public class Enemy : StateMachine
{
    
    [HideInInspector] public MeshRenderer renderer;
    [HideInInspector] public Player player;
    [HideInInspector] public PhysicsComponent physics;
    [HideInInspector] public LayerMask visionBlock;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Animator animator;
    
    [SerializeField] private GameObject[] patrolLocations;

    /// <summary>
    /// Sets almost all component on the enemy.
    /// </summary>
    protected override void Awake()
    {
    	renderer = GetComponent<MeshRenderer>();
	    agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        physics = GetComponent<PhysicsComponent>();
        visionBlock = LayerMask.GetMask("Geometry");
        animator = GetComponent<Animator>();

        base.Awake();
    }

    private void OnDestroy()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    /// <summary>
    /// Checks if the enemy can see the player, to prevent chasing when player is on the other side of the wall.
    /// </summary>
    /// <returns></returns>
    /// returns true or falls if it can see the player or not.
    public bool CanSeePlayer()
    {
        if (player != null)
            return !Physics.Linecast(transform.position, player.transform.position, visionBlock);
        return false;
    }

    /// <summary>
    /// Gets the distance between the player and the enemy
    /// </summary>
    /// <returns></returns>
    /// returns the distance between the player and the enemy
    public float GetDistance()
    {
        if(player != null)
        {
        return Vector3.Distance(player.transform.position, transform.position);
        }
            return 0f;
        
    }

    /// <summary>
    /// Gets the array of points the enemy patroles between.
    /// </summary>
    /// <returns></returns>
    /// returns an array with locations.
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
}
