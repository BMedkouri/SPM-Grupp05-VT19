using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class DarkWolfBehavoirTree : BehaviourTree
{
    [SerializeField] private float timerOnDarkAttack;
    [SerializeField] private float attackTimer;
    [SerializeField] private float procent;

    public bool AreaOnEffect { get; set; }

    /// <summary>
    /// The selector goes thro each sequence and return the first one that returns true on it's own.
    /// This enemy checks if it can see the enemy then it makes an aoe attack all the time.
    /// </summary>
    /// <returns>repeater, telling the behaviour what behaviour to repeat</returns>
    protected override Node CreateBehaviourTree()
    {
        Selector wolfSelector = new Selector("wolfSequence",

           new Sequence("areaAttack",
               new CheckMyHealth(procent),
               new CheckBool(),
               new Timer(timerOnDarkAttack),
               new AreaOnEffectAttack()),

            new Sequence("moveToPlayer",
                new HasPlayer(),
                new CheckDisntanceToPlayer(ChaseRange),
                new CanSeePlayer(),
                new Inverter(new CanAttackPlayer()),
                new SetDestinationToPlayer(),
                new MoveToPlayer(runbackLocation)),
            
            new Sequence("attackPlayer",
                new HasPlayer(),
                new CheckDisntanceToPlayer(AttackRange),
                new AttackPlayer(attackTimer)),
            
            new Sequence("patrole",
                new SetPatrolPoint(runbackLocation),
                new Move())

                );
         
        repeater = new Repeater(wolfSelector);
        return repeater;
    }
}
