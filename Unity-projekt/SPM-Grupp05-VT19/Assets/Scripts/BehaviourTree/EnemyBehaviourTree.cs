using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviourTree : MonoBehaviour
{
    Node behaviourTree;
    Behaviour currentBehaviourState;
    public NavMeshAgent Agent { get; private set; }
    public float AttackRange { get => attackRange; private set => attackRange = value; }
    public float ChaseRange { get => chaseRange; private set => chaseRange = value; }
    public Vector3[] PatrolePoints { get => patrolePoints; private set => patrolePoints = value; }
    
    private Node selectedBehaviour;

    [SerializeField] private float attackRange;
    [SerializeField] private float chaseRange;
    [SerializeField] private Vector3[] patrolePoints;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        behaviourTree = CreateBehaviourTree();
        currentBehaviourState = new Behaviour(this);  // optionally add things you might need access to in your leaf nodes

    }
    void FixedUpdate()
    {
        behaviourTree.Behave(currentBehaviourState);
    }
    Node CreateBehaviourTree()
    {

        Selector choosSequence = new Selector("choosSequence",
            new Sequence("moveToPlayer",
                new HasPlayer(),
                new CheckDisntanceToPlayer(ChaseRange),
                new Inverter(new CanAttackPlayer()),
                new SetDestinationToPlayer(),
                new Move()),
            new Sequence("attackPlayer",
                new HasPlayer(),
                new CheckDisntanceToPlayer(AttackRange),
                new AttackPlayer()),
            new Sequence("patrole",
                new SetPatrolPoint(),
                new Move())
            
            );


        Sequence patrole = new Sequence("patrole",
           new SetPatrolPoint(),
           new Move());

        Sequence moveToPlayer = new Sequence("moveToPlayer",
            new HasPlayer(),
            new CheckDisntanceToPlayer(ChaseRange),
            new Inverter(new CanAttackPlayer()),
            new SetDestinationToPlayer(),
            new Move());

        Sequence attackPlayer = new Sequence("attackPlayer",
            new HasPlayer(),
            new AttackPlayer()
            );
        
        Repeater repeater = new Repeater(choosSequence);

        return repeater;


    }

    public bool CanSeePlayer()
    {

        if (Player.PlayerReference != null)
        {
            return !Physics.Linecast(transform.position, Player.PlayerReference.transform.position, LayerMask.GetMask("Geometry"));
        }
        return false;
    }

    public void RotateToTarget(Vector3 target)
    {
        Vector3 targetDir = target - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 7f * Time.deltaTime, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
