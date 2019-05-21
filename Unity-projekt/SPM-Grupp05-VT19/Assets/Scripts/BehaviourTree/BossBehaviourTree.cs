using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviourTree : BehaviourTree
{
    private bool areaAttack;

    protected override Node CreateBehaviourTree()
    {
        Selector bossSelector = new Selector("bossSequence",
            new Sequence("areaAttack",
                new CheckMyHealth(30f),
                new Timer(),
                new AreaOnEffectAttack(areaAttack)),
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

        repeater = new Repeater(bossSelector);
        return repeater;
    }
}
