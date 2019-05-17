//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;
using UnityEngine.AI;

public class Enemy : StateMachine
{
    // Attributes    

    [Header("Enemy Patrol Locations:")]
    [SerializeField] private GameObject[] patrolLocations;


    // Properties
    public MeshRenderer Renderer { get; set; }
    public Animator Animator { get; set; }

    // TODO: Create a separate script for enemy movement (perhaps(?))
    public LayerMask LayerMask { get; private set; }
    public NavMeshAgent Agent { get; set; }

    /// <summary>
    /// Sets almost all component on the enemy.
    /// </summary>
    protected override void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
        Agent = GetComponent<NavMeshAgent>();
        LayerMask = LayerMask.GetMask("Geometry");
        Animator = GetComponent<Animator>();

        base.Awake();
    }

    /// <summary>
    /// Checks if the enemy can see the player, to prevent chasing when player is on the other side of the wall.
    /// </summary>
    /// <returns>
    /// returns true or falls if it can see the player or not.
    /// </returns>
    public bool CanSeePlayer()
    {
        if (Player.PlayerReference != null)
            return !Physics.Linecast(transform.position, Player.PlayerReference.transform.position, LayerMask);
        return false;
    }

    /// <summary>
    /// Gets the distance between the player and the enemy
    /// </summary>
    /// <returns></returns>
    /// returns the distance between the player and the enemy
    public float GetDistance()
    {
        if (Player.PlayerReference != null)
        {
            return Vector3.Distance(Player.PlayerReference.transform.position, transform.position);
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
        for (int i = 0; i < patrolLocations.Length; i++)
        {
            Debug.Log("MovePoints");
            movePoints[i] = patrolLocations[i].transform.position;
        }
        return movePoints;
    }
}
