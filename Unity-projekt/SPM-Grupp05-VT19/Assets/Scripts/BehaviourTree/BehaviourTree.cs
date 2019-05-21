using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BehaviourTree : MonoBehaviour
{
    protected Repeater repeater;
    protected Node behaviourTree;
    protected Behaviour currentBehaviourState;
    public NavMeshAgent Agent { get; private set; }
    public float AttackRange { get => attackRange; private set => attackRange = value; }
    public float ChaseRange { get => chaseRange; private set => chaseRange = value; }
    public Vector3[] PatrolePoints { get => patrolePoints; private set => patrolePoints = value; }
    public Animator Animator { get => animator; private set => animator = value; }

    protected Node selectedBehaviour;

    private bool areaOnEffect = true;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float chaseRange;
    [SerializeField] protected Vector3[] patrolePoints;
    protected Animator animator;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    protected void Start()
    {
        behaviourTree = CreateBehaviourTree();
        currentBehaviourState = new Behaviour(this);  // optionally add things you might need access to in your leaf nodes
    }

    protected void FixedUpdate()
    {
        behaviourTree.Behave(currentBehaviourState);
    }

    // Update is called once per frame

    protected abstract Node CreateBehaviourTree();

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
