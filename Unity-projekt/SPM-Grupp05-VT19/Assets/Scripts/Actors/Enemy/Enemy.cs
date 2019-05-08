//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

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

    public bool CanSeePlayer()
    {
        if (player != null)
            return !Physics.Linecast(transform.position, player.transform.position, visionBlock);
        return false;
    }

    public float GetDistance()
    {
        if(player != null)
        {
        return Vector3.Distance(player.transform.position, transform.position);
        }
            return 0f;
        
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
}
