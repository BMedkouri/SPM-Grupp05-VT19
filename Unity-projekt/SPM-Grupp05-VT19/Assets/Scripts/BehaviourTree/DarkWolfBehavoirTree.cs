using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWolfBehavoirTree : BehaviourTree
{
    [SerializeField] private float timerOnDarkAttack;

    public bool AreaOnEffect { get; set; }
    
    protected override Node CreateBehaviourTree()
    {
        Sequence area = new Sequence("area",
            new CanSeePlayer(),
            new Timer(),
            new AreaOnEffectAttack(AreaOnEffect = true));
        repeater = new Repeater(area);
        return repeater;
    }
}
