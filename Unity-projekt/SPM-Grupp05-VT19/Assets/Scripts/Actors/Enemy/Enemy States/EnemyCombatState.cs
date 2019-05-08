using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * @author Anders Ragnar
 * @co-author Bilal El Medkouri
 */
[CreateAssetMenu(menuName = "Enemy States/EnemyCombatState")]
public class EnemyCombatState : EnemyBaseState
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private Material ParryMaterial;
    private float attackTimer;

    /// <summary>
    /// Sets the attackTimer.
    /// </summary>
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
        }else if (!owner.CanSeePlayer())
        {
            owner.Transition<EnemyIdleState>();
        }
        //måste ändra så att den inte tittar ifall man redan tittar mot spelaren
        rotateToTarget();
        AttackPlayer();
        base.HandleUpdate();
    }

    /// <summary>
    /// Checks if it's the time to attack player and changes to attackstate when it is.
    /// </summary>
    private void AttackPlayer()
    {
        if (attackTimer <= 0)
        {
            owner.Transition<EnemyAttackState>();
               
        }
        if(attackTimer < 0.5f && attackTimer > 0.01f)
        {
            owner.renderer.material = ParryMaterial;
            if (Input.GetMouseButtonDown(1))
            {
                owner.Transition<EnemyImmobilisedState>();
            }
        }
        
        attackTimer -= Time.deltaTime;
    }

    /// <summary>
    /// Rotates the enemy towards the player.
    /// </summary>
    private void rotateToTarget()
    {
        Vector3 targetDir = owner.player.transform.position - owner.transform.position;

        Vector3 newDir = Vector3.RotateTowards(owner.transform.forward, targetDir, movementSpeed * Time.deltaTime, 0.0f);

        // Move our position a step closer to the target.
        owner.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
