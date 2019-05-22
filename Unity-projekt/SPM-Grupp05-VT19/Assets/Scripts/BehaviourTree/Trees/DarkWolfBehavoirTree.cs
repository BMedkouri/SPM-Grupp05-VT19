using UnityEngine;
/*
 * @author Anders Ragnar
 */
public class DarkWolfBehavoirTree : BehaviourTree
{
    [SerializeField] private float timerOnDarkAttack;

    public bool AreaOnEffect { get; set; }

    /// <summary>
    /// The selector goes thro each sequence and return the first one that returns true on it's own.
    /// This enemy checks if it can see the enemy then it makes an aoe attack all the time.
    /// </summary>
    /// <returns>repeater, telling the behaviour what behaviour to repeat</returns>
    protected override Node CreateBehaviourTree()
    {
        Sequence area = new Sequence("area",
            new CanSeePlayer(),
            new Timer(),
            new AreaOnEffectAttack(timerOnDarkAttack));
        repeater = new Repeater(area);
        return repeater;
    }
}
