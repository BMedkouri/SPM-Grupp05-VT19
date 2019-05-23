using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class WolfBehaviourTree : BehaviourTree
{
    [SerializeField] private float attackTime;
    /// <summary>
    /// the selector goes thro each sequence and return the first one that returns true on it's own
    /// </summary>
    /// <returns>repeater, telling the behaviour what behaviour to repeat</returns>
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
                new AttackPlayer(attackTime)),
            new Sequence("patrole",
                new SetPatrolPoint(movePoints),
                new Move())
            );
        Repeater repeater = new Repeater(wolfSelector);
        return repeater;
    }
}
