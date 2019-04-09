using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Attack")]
public class Attack : EnemyBaseState
{

    [SerializeField] private float attackSpeed;
    private float attackTimer;

    public override void Enter()
    {
        base.Enter();
        attackTimer = attackSpeed;
    }
    public override void HandleUpdate()
    {
        if (GetDistance() > 2.8f)
        {
            owner.Transition<Chasing>();
        }

        AttackPlayer();
    }
    private void AttackPlayer()
    {
        if (attackTimer <= 0)
        {
            if (owner.player.GetCurrentHealth() > 0)
            {
                Debug.Log("Hit!");
                owner.player.TakeDamage(15);
            }
            attackTimer = attackSpeed;
        }
        
        attackTimer -= Time.deltaTime;
    }
}