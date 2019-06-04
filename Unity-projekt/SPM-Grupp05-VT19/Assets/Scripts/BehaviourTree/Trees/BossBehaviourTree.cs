using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* @author Anders Ragnar
*/
public class BossBehaviourTree : BehaviourTree
{
    
    [SerializeField] private float timerOnDarkAttack;
    [SerializeField] private float meeleAttackTimer;
    [SerializeField] private float procentHealth;
    [SerializeField] private Scene bossWin;

    public Dictionary<string, float> Attacktimes { get; private set; }

    private void OnEnable()
    {
        CanDoDarkAttack = true;
        Attacktimes = new Dictionary<string, float>();
        Attacktimes.Add("Attack", 2.933f);
        Attacktimes.Add("Attack2", 3.44f);
        Attacktimes.Add("Attack3", 3.2f);
        Attacktimes.Add("Attack4", 3.567f);
        Attacktimes.Add("Attack5", 1.9f);
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
                new DarkAttackTimer(timerOnDarkAttack),
                new AreaOnEffectAttack()),

            new Sequence("moveToPlayer",
                new HasPlayer(),
                new CheckDisntanceToPlayer(ChaseRange),
                new CanSeePlayer(),
                new Inverter(new CanAttackPlayer()),
                new SetDestinationToPlayer(),
                new Move()),

            new Sequence("attackPlayer",
                new HasPlayer(),
                new CheckDisntanceToPlayer(AttackRange),
                new BossAttackTimer(meeleAttackTimer),
                new AttackPlayer(attack))
            );

        
        repeater = new Repeater(bossSelector);
        return repeater;

    }
    public override void DisableScript()
    {
        base.DisableScript();
        Invoke("EndGame", 3f);
    }
    
    public void EndGame()
    {
        SceneManager.LoadScene(3);
    }
}
