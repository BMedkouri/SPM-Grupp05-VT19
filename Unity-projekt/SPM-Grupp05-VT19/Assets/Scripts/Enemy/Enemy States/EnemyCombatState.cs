using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyCombatState")]
public class EnemyCombatState : EnemyBaseState
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private Material ParryMaterial;
    private float attackTimer;

    public override void Enter()
    {
        base.Enter();
        attackTimer = attackSpeed;
        attackRange = 2.8f;
    }
    public override void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            owner.Transition<EnemyImmobilisedState>();
        }
        if (owner.GetDistance() > attackRange)
        {
            owner.Transition<EnemyChaseState>();
        }else if (!owner.CanSeePlayer())
        {
            owner.Transition<EnemyIdleState>();
        }
        //måste ändra så att den tittar ifall man redan tittar mot spelaren
        rotateToTarget();
        AttackPlayer();
        base.HandleUpdate();
    }
    private void AttackPlayer()
    {
        if (attackTimer <= 0)
        {
            //if (owner.player.GetCurrentHealth() > 0)
            //{
                
            //    owner.Transition<EnemyAttackState>();
            //    //owner.player.TakeDamage(attackDamage);
            //}
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
    private void rotateToTarget()
    {
        Vector3 targetDir = owner.player.transform.position - owner.transform.position;

        Vector3 newDir = Vector3.RotateTowards(owner.transform.forward, targetDir, movementSpeed * Time.deltaTime, 0.0f);

        // Move our position a step closer to the target.
        owner.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
