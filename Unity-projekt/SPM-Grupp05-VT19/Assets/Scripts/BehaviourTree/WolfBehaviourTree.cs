using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfBehaviourTree : BehaviourTree
{
    protected override Node CreateBehaviourTree()
    {
        Selector wolfSelector = new Selector("wolfSequence",
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
        Repeater repeater = new Repeater(wolfSelector);
        return repeater;
    }
}
