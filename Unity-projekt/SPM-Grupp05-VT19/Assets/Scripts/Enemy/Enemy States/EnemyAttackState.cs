using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy States/EnemyAttackState")]
public class EnemyAttackState : EnemyBaseState
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackDamage;
    private float attackTimer;

    public override void Enter()
    {
        base.Enter();
        attackTimer = 0.0f;
    }
    public override void HandleUpdate()
    {
        //Ändra float till variabel som kan ändras i inspector
        if (owner.GetDistance() > 2.8f)
        {
            owner.Transition<EnemyChaseState>();
        }

        AttackPlayer();
    }
    private void AttackPlayer()
    {
        if (attackTimer <= 0)
        {
            if (owner.player.GetCurrentHealth() > 0)
            {
                Debug.Log("Enemy hit player for " + attackDamage + "!");
                owner.player.TakeDamage(attackDamage);
            }
            attackTimer = attackSpeed;
        }
        
        attackTimer -= Time.deltaTime;
    }
}