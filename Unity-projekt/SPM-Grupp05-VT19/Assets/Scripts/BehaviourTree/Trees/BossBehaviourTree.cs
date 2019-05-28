using System.Collections;
using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class BossBehaviourTree : BehaviourTree
{
    
    [SerializeField] private float timerOnDarkAttack;
    [SerializeField] private float meeleAttackTimer;
    [SerializeField] private float procentHealth;

    //animationers x och y movement, kanske vi vill flytta ut till behaviour eftersom alla vill ha rörelse animationer
    private float xMovement;
    private float yMovement;
  
    private void OnEnable()
    {
        CanDoDarkAttack = true;
    }


    protected override void FixedUpdate()
    {
        xMovement = Agent.velocity.x;
        yMovement = Agent.velocity.y;
        base.FixedUpdate();
        animator.SetFloat("Speed", xMovement);
        animator.SetFloat("Direction", yMovement);
    }

    /// <summary>
    /// The selector goes thro each sequence and return the first one that returns true on it's own.
    /// This enemy checks if it's under a special amount of health and then it makes another attack aswell.
    /// </summary>
    /// <returns>repeater, telling the behaviour what behaviour to repeat</returns>
    protected override Node CreateBehaviourTree()
    {
        Selector bossSelector = new Selector("bossSequence",
          
            new Sequence("areaAttack",
                new CheckMyHealth(procentHealth),
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
                new AttackPlayer(meeleAttackTimer))
            
            //new Sequence("patrole",
            //    new SetPatrolPoint(runbackLocation),
            //    new Move())
            );

        repeater = new Repeater(bossSelector);
        return repeater;

    }

    

}
