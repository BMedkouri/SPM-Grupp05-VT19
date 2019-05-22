using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourTree : BehaviourTree
{
    [SerializeField] private float areaAttackTimer;
    [SerializeField] private float meeleAttackTimer;
    [SerializeField] private float procentHealth;
    private float xMovement;
    private float yMovement;
    protected override void FixedUpdate()
    {
        xMovement = Agent.velocity.x;
        yMovement = Agent.velocity.y;
        base.FixedUpdate();
        animator.SetFloat("Speed", xMovement);
        animator.SetFloat("Direction", yMovement);
    }
    protected override Node CreateBehaviourTree()
    {
        Selector bossSelector = new Selector("bossSequence",
            new Sequence("areaAttack",
                new CheckMyHealth(procentHealth),
                new Timer(),
                new AreaOnEffectAttack(areaAttackTimer)),
            new Sequence("moveToPlayer",
                new HasPlayer(),
                new CheckDisntanceToPlayer(ChaseRange),
                new Inverter(new CanAttackPlayer()),
                new SetDestinationToPlayer(),
                new Move()),
            new Sequence("attackPlayer",
                new HasPlayer(),
                new CheckDisntanceToPlayer(AttackRange),
                new AttackPlayer(meeleAttackTimer)),
            new Sequence("patrole",
                new SetPatrolPoint(),
                new Move())
            );

        repeater = new Repeater(bossSelector);
        return repeater;
    }
}
