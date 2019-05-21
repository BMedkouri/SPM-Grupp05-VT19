using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOnEffectAttack : Leaf
{
    private bool canAttack;
    public AreaOnEffectAttack(bool attack)
    {
        canAttack = attack;
    }
    
    public override NodeStatus OnBehave(BehaviourState state)
    {
        if(canAttack == false)
        {
            return NodeStatus.FAILURE;
        }
        return NodeStatus.SUCCESS;
    }

    public override void OnReset()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
