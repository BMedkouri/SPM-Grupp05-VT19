using UnityEngine;
using UnityEngine.AI;
/*
 * @author Anders Ragnar
 */


/// <summary>
/// This is a baseclass for all enemies that need a behaviour tree.
/// It could be structed into more underclasses if there was a big variation on the enemies.
/// </summary>
public abstract class BehaviourTree : MonoBehaviour
{
    //non inspector variable
    protected Repeater repeater;
    protected Node behaviourTree;
    protected Behaviour currentBehaviourState;
    protected Animator animator;
    private bool areaOnEffect = true;

    //inspector variable
    [SerializeField] protected float attackRange;
    [SerializeField] protected float chaseRange;
    [SerializeField] protected Vector3[] patrolePoints;

    //properties
    public NavMeshAgent Agent { get; private set; }
    public float AttackRange { get => attackRange; private set => attackRange = value; }
    public float ChaseRange { get => chaseRange; private set => chaseRange = value; }
    public Vector3[] PatrolePoints { get => patrolePoints; private set => patrolePoints = value; }
    public Animator Animator { get => animator; private set => animator = value; }
    
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

    //since this is not my code I'm a bit uncertain if this needs to be in the Fixedupdate
    protected virtual void FixedUpdate()
    {
        behaviourTree.Behave(currentBehaviourState);
    }

    // Update is called once per frame

    protected abstract Node CreateBehaviourTree();

    /// <summary>
    /// Makes a raycast between the enemy and the player
    /// </summary>
    /// <returns>true if the enemy can see the player</returns>
    public bool CanSeePlayer()
    {

        if (Player.PlayerReference != null)
        {
            return !Physics.Linecast(transform.position, Player.PlayerReference.transform.position, LayerMask.GetMask("Geometry"));
        }
        return false;
    }

    /// <summary>
    /// rotates the enemy towards the target
    /// </summary>
    /// <param name="target">the target we want the enemy to rotate to</param>
    public void RotateToTarget(Vector3 target)
    {
        Vector3 targetDir = target - transform.position;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 7f * Time.deltaTime, 0.0f);

        // Move our position a step closer to the target.
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
