//Main author: Anders Ragnar
//Secondary author: Bilal El Medkouri

using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyCombatState")]
public class EnemyCombatState : EnemyBaseState
{
    // Attributes

    [Header("Combat properties:")]
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;
    private float attackTimer;

    public override void Enter()
    {
        base.Enter();
        attackTimer = attackSpeed;
    }

    /// <summary>
    /// Checks if the enemy is in range of attacking the player or can see the player.
    /// </summary>
    public override void HandleUpdate()
    {
        if (owner.GetDistance() > attackRange)
        {
            owner.Transition<EnemyChaseState>();
        }
        else if (!owner.CanSeePlayer())
        {
            owner.Transition<EnemyIdleState>();
        }

        // TODO: Only rotate if not already facing the player
        RotateToTarget();

        AttackCountdown();

        base.HandleUpdate();
    }

    /// <summary>
    /// Checks if it's the time to attack player and changes to attackstate when it is.
    /// </summary>
    private void AttackCountdown()
    {
        if (attackTimer <= 0)
        {
            AttackPlayer();
        }

        attackTimer -= Time.deltaTime;
    }

    private void AttackPlayer()
    {
        owner.Transition<EnemyAttackState>();
    }

    /// <summary>
    /// Rotates the enemy towards the player.
    /// </summary>
    private void RotateToTarget()
    {
        Vector3 targetDir = Player.Instance.transform.position - owner.transform.position;

        Vector3 newDir = Vector3.RotateTowards(owner.transform.forward, targetDir, movementSpeed * Time.deltaTime, 0.0f);

        // Move our position a step closer to the target.
        owner.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
